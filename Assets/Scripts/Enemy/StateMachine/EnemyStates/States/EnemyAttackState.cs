using Game.Core;

namespace Game.Enemy
{
    public class EnemyAttackState : EnemyState
    {
        private readonly EnemyStateMachine _fsm;

        private readonly EnemyCombatController _combat;

        private readonly EnemyStateType _nextState;

        public EnemyAttackState(EnemyStateMachine fsm, EnemyCombatController combat, EnemyStateType nextState)
        {
            _fsm = fsm;
            _combat = combat;

            _nextState = nextState;
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void Update()
        {
            _combat.Attack();

            _fsm.ChangeState(_nextState);
        }
    }

}
