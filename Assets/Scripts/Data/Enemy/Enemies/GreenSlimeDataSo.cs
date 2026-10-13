using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "GreenSlimeDataSo", menuName = "Scriptable Objects/GreenSlimeDataSo")]
    public class GreenSlimeDataSo : EnemyDataSo
{
        [SerializeField] private EnemyMovementDataSo _movementData;
        public EnemyMovementDataSo MovementData => _movementData;
    }
}
