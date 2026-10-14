using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyLocomotionDataSo", menuName = "Scriptable Objects/EnemyLocomotionDataSo")]
    public class EnemyLocomotionDataSo : ScriptableObject
    {
        [SerializeField] private EnemyMovementDataSo _movementData;
        public EnemyMovementDataSo MovementData => _movementData;
    }

}
