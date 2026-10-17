using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "FromWaitTransitionDataSo", menuName = "Scriptable Objects/FromWaitTransitionDataSo")]
    public class FromWaitTransitionDataSo : ScriptableObject
    {
        [SerializeField] private EnemyStateType _nextState;
        public EnemyStateType NextState => _nextState;

        [SerializeField] private float _waitTime;
        public float WaitTime => _waitTime; 
    }

}

