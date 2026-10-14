using UnityEngine;

namespace Game.Enemy
{
    public class EnemyIdleState : EnemyState
    {
        private readonly EnemyStateMachine _fsm;

        private readonly EnemyAwarenessController _awareness;

        public EnemyIdleState(EnemyStateMachine fsm, EnemyAwarenessController awareness)
        {
            _fsm = fsm;
            _awareness = awareness;
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void Update()
        {
            if (!_awareness.HasDetectedTarget()) return;
                        
            _fsm.ChangeState(EnemyStateType.Move);
        }
    }
}

