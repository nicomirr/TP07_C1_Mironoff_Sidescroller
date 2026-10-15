using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyMovementDataSo", menuName = "Scriptable Objects/EnemyMovementDataSo")]
    public class EnemyMovementDataSo : ScriptableObject
    {
        [SerializeField] private EnemyMovementType _movementType;
        public EnemyMovementType MovementType => _movementType;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;
    }
}

