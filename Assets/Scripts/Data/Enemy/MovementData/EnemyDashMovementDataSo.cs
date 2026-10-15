using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyDashMovementDataSo", menuName = "Scriptable Objects/EnemyDashMovementDataSo")]
    public class EnemyDashMovementDataSo : EnemyMovementDataSo
    {
        [SerializeField] private float _speedMultiplier;
        public float SpeedMultiplier => _speedMultiplier;

        [SerializeField] private float _minDelayTime;
        public float MinDelayTime => _minDelayTime;

        [SerializeField] private float _maxDelayTime;
        public float MaxDelayTime => _maxDelayTime;

        [SerializeField] private float _waitTime;
        public float WaitTime => _waitTime;

        [SerializeField] private float _dashTime;
        public float DashTime => _dashTime;
    }
}

