using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyStateMachineTransitionsSo", menuName = "Scriptable Objects/EnemyStateMachineTransitionsSo")]
    public class EnemyStateMachineTransitionsSo : ScriptableObject
    {
        [SerializeField] private EnemyStateType _fromIdleTransition;
        public EnemyStateType FromIdleTransition => _fromIdleTransition;

        [SerializeField] private EnemyStateType _fromJumpTransition;
        public EnemyStateType FromJumpTransition => _fromJumpTransition;

        [SerializeField] private FromWaitTransitionDataSo _waitTransitionData;
        public FromWaitTransitionDataSo WaitTransitionData => _waitTransitionData;

    }

}

