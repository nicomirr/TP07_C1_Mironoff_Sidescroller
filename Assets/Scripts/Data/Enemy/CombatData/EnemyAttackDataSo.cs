using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyAttackDataSo", menuName = "Scriptable Objects/EnemyAttackDataSo")]
    public class EnemyAttackDataSo : ScriptableObject
    {
        [SerializeField] private EnemyAttackType _attackType;
        public EnemyAttackType AttackType => _attackType;

        [SerializeField] private float _cooldown;
        public float Cooldown => _cooldown;
    }
}

    



