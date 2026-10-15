using UnityEngine;
using System;
using Game.Core;
using Game.Data;
using Game.Common;

namespace Game.Enemy
{
    public class EnemyHealthController : MonoBehaviour, IHealthChangedNotifier
    {
        [SerializeField] private HealthDataSo _data;

        private Health _health;
        private EnemyDeath _death;

        public event Action<float, float> OnHealthChanged;

        private void Awake()
        {
            _health = new Health(_data);
            _death = new EnemyDeath(_data, this.gameObject);
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += RaiseHealthChanged;
            _health.OnHealthChanged += _death.HandleDeath;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= RaiseHealthChanged;
            _health.OnHealthChanged -= _death.HandleDeath;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out IDamageProvider damageProvider))
                return;

            _health.TakeDamage(damageProvider.Damage);
        }

        private void RaiseHealthChanged(float currentHealth, float maxHealth)
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

    }
}

