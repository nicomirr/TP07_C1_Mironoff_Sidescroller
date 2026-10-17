using UnityEngine;
using Game.Core;
using Game.Data;
using System.Collections;

namespace Game.Enemy
{
    [RequireComponent(typeof(EnemyLocomotionController))]
    [RequireComponent(typeof(EnemyCombatController))]
    [RequireComponent(typeof(EnemyAwarenessController))]

    public class EnemyBrain : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private EnemyStateMachineTransitionsSo _data;

        private EnemyLocomotionController _locomotion;
        private EnemyCombatController _combat;
        private EnemyAwarenessController _awareness;

        private EnemyStateMachine _fsm;

        

        private void Awake()
        {
            _locomotion = GetComponent<EnemyLocomotionController>();
            _combat = GetComponent<EnemyCombatController>();
            _awareness = GetComponent<EnemyAwarenessController>();

            _fsm = new EnemyStateMachine();

            EnemyIdleState idleState = new EnemyIdleState(_fsm, _awareness, _data.FromIdleTransition);
            EnemyMoveState moveState = new EnemyMoveState(_fsm, _locomotion);
            EnemyJumpState jumpState = new EnemyJumpState(_fsm, _locomotion, _data.FromJumpTransition);
            EnemyWaitState waitState = new EnemyWaitState(_fsm, _awareness, _data.WaitTransitionData.NextState, this, _data.WaitTransitionData.WaitTime);

            _fsm.AddState(EnemyStateType.Idle, idleState);
            _fsm.AddState(EnemyStateType.Move, moveState);
            _fsm.AddState(EnemyStateType.Jump, jumpState);  
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

    }
}
