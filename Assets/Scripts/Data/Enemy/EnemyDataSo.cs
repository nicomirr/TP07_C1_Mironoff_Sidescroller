using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyDataSo", menuName = "Scriptable Objects/EnemyDataSo")]
    public class EnemyDataSo : ScriptableObject
    {        
        [SerializeField] private HealthDataSo _healthData;
        public HealthDataSo HealthData => _healthData;

        [SerializeField] private float _contactDamage;
        public float ContactDamage => _contactDamage;   
    }

}

