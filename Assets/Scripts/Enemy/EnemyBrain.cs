using UnityEngine;

namespace Game.Enemy
{
    [RequireComponent(typeof(EnemyLocomotionController))]
    [RequireComponent(typeof(EnemyCombatController))]
    [RequireComponent(typeof(EnemyAwarenessController))]

    public class EnemyBrain : MonoBehaviour
    {
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

            EnemyIdleState idleState = new EnemyIdleState(_fsm, _awareness);
            EnemyMoveState activeState = new EnemyMoveState(_fsm, _locomotion);

            _fsm.AddState(EnemyStateType.Idle, idleState);
            _fsm.AddState(EnemyStateType.Move, activeState);

            _fsm.SetInitialState(idleState);            
        }

        private void Update()
        {
            _fsm.Update();
        }
    }
}
