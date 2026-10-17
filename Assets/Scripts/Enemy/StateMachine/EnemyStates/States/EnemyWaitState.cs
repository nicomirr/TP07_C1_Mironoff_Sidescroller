using UnityEngine;
using Game.Core;
using System.Collections;

namespace Game.Enemy
{
    public class EnemyWaitState : EnemyState
    {
        private readonly EnemyStateMachine _fsm;

        private readonly EnemyAwarenessController _awareness;

        private readonly EnemyStateType _nextState;

        private readonly ICoroutineRunner _coroutineRunner;

        private readonly float _waitTime;
                
        public EnemyWaitState(EnemyStateMachine fsm, EnemyAwarenessController awareness, EnemyStateType nextState, 
            ICoroutineRunner coroutineRunner, float waitTime)
        {
            _fsm = fsm;
            _awareness = awareness;
            _nextState = nextState;
            _coroutineRunner = coroutineRunner;
            _waitTime = waitTime;
        }

        public override void Enter() 
        {
            _coroutineRunner.RunCoroutine(WaitRoutine());        
        }

        public override void Exit() 
        {
            _awareness.ResetTargetDetection();
        }

        public override void Update() { }

        private IEnumerator WaitRoutine()
        {
            yield return new WaitForSeconds(_waitTime);

            _fsm.ChangeState(_nextState);
        }
        
    }

}
