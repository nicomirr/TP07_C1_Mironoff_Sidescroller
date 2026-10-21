using Game.Core;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyJumpState : EnemyState
    {
        private readonly EnemyStateMachine _fsm;

        private readonly EnemyLocomotionController _locomotion;

        private readonly EnemyStateType _nextState;

        public EnemyJumpState(EnemyStateMachine fsm, EnemyLocomotionController locomotion, EnemyStateType nextState)
        {
            _fsm = fsm;
            _locomotion = locomotion;
            _nextState = nextState;
        }

        public override void Enter() { }

        public override void Exit() { }

        public override void Update()
        {           
            _locomotion.Jump(); 

            if(_nextState != EnemyStateType.None)         
                _fsm.ChangeState(_nextState);
        }
    }
}
