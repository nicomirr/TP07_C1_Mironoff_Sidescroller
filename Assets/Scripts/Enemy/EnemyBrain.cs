#nullable enable

using UnityEngine;
using Game.Core;
using Game.Data;
using System.Collections;
using Game.Audio;

namespace Game.Enemy
{
    [RequireComponent(typeof(EnemyLocomotionController))]
    [RequireComponent(typeof(EnemyCombatController))]
    [RequireComponent(typeof(EnemyAwarenessController))]

    public class EnemyBrain : MonoBehaviour, ICoroutineRunner, IReset
    {
        [SerializeField] private EnemyDataSo _data;

        private EnemyLocomotionController _locomotion;
        private EnemyCombatController _combat;
        private EnemyAwarenessController _awareness;
        private EnemyHealthController? _health;

        private EnemyStateMachine _fsm;        

        private void Awake()
        {
            _locomotion = GetComponent<EnemyLocomotionController>();
            _combat = GetComponent<EnemyCombatController>();
            _awareness = GetComponent<EnemyAwarenessController>();
            _health = GetComponent<EnemyHealthController>();

            AudioPlayer audioPlayer = new AudioPlayer(_data.AudioConfig, GetComponentInChildren<AudioSource>());
            
            _health?.Initialize(audioPlayer);
            _locomotion.Initialize(audioPlayer);

            _fsm = new EnemyStateMachine();

            EnemyIdleState idleState = new EnemyIdleState(_fsm, _awareness, _data.TransitionsData.FromIdleTransition);
            EnemyMoveState moveState = new EnemyMoveState(_fsm, _locomotion, _combat, _awareness, _data.TransitionsData.FromMoveTransition);
            EnemyJumpState jumpState = new EnemyJumpState(_fsm, _locomotion, _data.TransitionsData.FromJumpTransition);
            EnemyAttackState attackState = new EnemyAttackState(_fsm, _combat, _data.TransitionsData.FromAttackTransition);
            EnemyWaitState waitState = new EnemyWaitState(_fsm, _awareness, _data.TransitionsData.WaitTransitionData.NextState, 
                this, _data.TransitionsData.WaitTransitionData.WaitTime);

            _fsm.AddState(EnemyStateType.Idle, idleState);
            _fsm.AddState(EnemyStateType.Move, moveState);
            _fsm.AddState(EnemyStateType.Jump, jumpState);  
            _fsm.AddState(EnemyStateType.Attack, attackState);
            _fsm.AddState(EnemyStateType.Wait, waitState);

            _fsm.SetInitialState(idleState);            
        }

        private void Update()
        {
            _fsm.Update();
        }

        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void ResetObject()
        {
            _awareness.ResetTargetDetection();
            _health?.RestoreHealth();
            _fsm.ResetState();
        }
    }
}
