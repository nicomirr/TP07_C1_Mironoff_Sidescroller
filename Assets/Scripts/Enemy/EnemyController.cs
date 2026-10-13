using UnityEngine;
using Game.Core;
using Game.Common;
using Game.UI;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour, IDamageProvider
    {
        [SerializeField] private UIHealth _UIHealth;

        protected float _contactDamage;
        public float ContactDamage => _contactDamage;

        protected Health _health;
        private EnemyDeath _enemyDeath;


        protected virtual void Awake()
        {            
            _enemyDeath = new EnemyDeath(this.gameObject);
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += _UIHealth.UpdateHealth;
            _health.OnHealthChanged += _enemyDeath.HandleDeath;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= _UIHealth.UpdateHealth;
            _health.OnHealthChanged -= _enemyDeath.HandleDeath;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out IDamageProvider damageProvider))
                return;

            _health.TakeDamage(damageProvider.ContactDamage);
        }
    }
}

