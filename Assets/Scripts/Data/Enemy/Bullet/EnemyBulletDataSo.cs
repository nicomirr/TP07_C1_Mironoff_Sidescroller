using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyBulletDataSo", menuName = "Scriptable Objects/EnemyBulletDataSo")]
    public class EnemyBulletDataSo : ScriptableObject
    {
        [SerializeField] private float _speed;
        public float Speed => _speed;

        [SerializeField] private float _lifetime;
        public float Lifetime => _lifetime;

        [SerializeField] private int _damage;
        public int Damage => _damage;
    }

}

