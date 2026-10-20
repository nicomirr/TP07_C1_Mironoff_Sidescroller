using Game.Core;

namespace Game.Enemy
{
    public class EnemyMoveState : EnemyState
    {
        private readonly EnemyStateMachine _fsm;

        private readonly EnemyLocomotionController _locomotion;
        private readonly EnemyCombatController _combat;
        private readonly EnemyAwarenessController _awareness;

        private readonly EnemyStateType _nextState;

        public EnemyMoveState(EnemyStateMachine fsm, EnemyLocomotionController locomotion, EnemyCombatController combat,
            EnemyAwarenessController awareness, EnemyStateType nextState)
        {
            _fsm = fsm;
            _locomotion = locomotion;
            _combat = combat;
            _awareness = awareness;

            _nextState = nextState;
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void Update()
        {
            _locomotion.Move();

            if(_awareness.TargetInAttackRange() && _combat.CanAttack())
                _fsm.ChangeState(_nextState);
        }
    }

}
