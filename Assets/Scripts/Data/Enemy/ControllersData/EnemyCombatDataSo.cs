using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyCombatDataSo", menuName = "Scriptable Objects/EnemyCombatDataSo")]
    public class EnemyCombatDataSo : ScriptableObject
    {
        [SerializeField] private float _contactDamage;
        public float ContactDamage => _contactDamage;
    }
}

