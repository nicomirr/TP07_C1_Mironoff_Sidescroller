using Game.Core;

namespace Game.Enemy
{
    public class EnemyIdleState : EnemyState
    {
        private readonly EnemyStateMachine _fsm;

        private readonly EnemyAwarenessController _awareness;

        private readonly EnemyStateType _nextState;

        public EnemyIdleState(EnemyStateMachine fsm, EnemyAwarenessController awareness, EnemyStateType nextState)
        {
            _fsm = fsm;
            _awareness = awareness;
            _nextState = nextState;
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void Update()
        {
            if (!_awareness.HasDetectedTarget()) return;
                        
            _fsm.ChangeState(_nextState);
        }
    }
}

