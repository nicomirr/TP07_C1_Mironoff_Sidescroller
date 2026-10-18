using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyDataSo", menuName = "Scriptable Objects/EnemyDataSo")]
    public class EnemyDataSo : ScriptableObject
    {
        [SerializeField] private EnemyStateMachineTransitionsSo _transitionsData;
        public EnemyStateMachineTransitionsSo TransitionsData => _transitionsData;

        [SerializeField] private AudioConfigSo _audioConfig;
        public AudioConfigSo AudioConfig => _audioConfig;
    }
}

