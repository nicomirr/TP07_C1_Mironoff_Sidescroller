#nullable enable

using Game.Core;
using Game.Data;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyCombatController : MonoBehaviour, IDamageProvider
    {
        [SerializeField] private EnemyCombatDataSo _data;

        public float Damage => _data.ContactDamage;
    }
}

