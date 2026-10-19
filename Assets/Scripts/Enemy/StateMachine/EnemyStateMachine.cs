using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Enemy
{
    public class EnemyStateMachine
    {
        private readonly Dictionary<EnemyStateType, EnemyState> _states = new();

        private EnemyState _currentState;
                
        public void AddState(EnemyStateType type, EnemyState state)
        {
            if (_states.ContainsKey(type))
            {
                Debug.LogError("Error. No deberian repetirse los estados del enemigo.");
                return;
            }

            _states[type] = state;
        }

        public void SetInitialState(EnemyState initialState)
        {
            _currentState = initialState;
            _currentState.Enter();
        }

        public void ChangeState(EnemyStateType stateType)
        {
            _currentState.Exit();

            _currentState = _states[stateType];

            _currentState.Enter();
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void ResetState()
        {
            _currentState = _states[EnemyStateType.Idle];
            _currentState.Enter();
        }
    }
}
