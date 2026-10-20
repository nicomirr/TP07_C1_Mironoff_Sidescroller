using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyRangedDownwardsAttackDataSo", menuName = "Scriptable Objects/EnemyRangedDownwardsAttackDataSo")]
    public class EnemyRangedDownwardsAttackDataSo : EnemyAttackDataSo
    {
        [SerializeField] private GameObject _bulletPrefab;
        public GameObject BulletPrefab => _bulletPrefab;

        [SerializeField] private int _bulletAmount;
        public int BulletAmount => _bulletAmount;   
    }
}

