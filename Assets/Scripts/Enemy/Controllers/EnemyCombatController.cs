#nullable enable

using UnityEngine;
using Game.Core;
using Game.Data;
using System.Collections;

namespace Game.Enemy
{
    public class EnemyCombatController : MonoBehaviour, IDamageProvider, ICoroutineRunner
    {
        [SerializeField] private EnemyCombatDataSo _data;
        [SerializeField] private Transform _bulletsParent;

        private EnemyAttack? _enemyAttack;

        public float Damage => _data.ContactDamage;

        private void Awake()
        {
            _enemyAttack = EnemyCombatFactory.CreateAttack(_data.AttackData, this.transform, this, _bulletsParent);
        }
        
        public void Attack()
        {
            _enemyAttack?.Attack();
        }

        public bool CanAttack()
        {
            return _enemyAttack != null ? _enemyAttack.CanAttack : false;
        }

        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }
    }
}

