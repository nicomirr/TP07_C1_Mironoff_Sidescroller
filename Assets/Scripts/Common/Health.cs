using UnityEngine;
using System;
using Game.Data;
using Game.Core;

namespace Game.Common
{
    public class Health
    {
        public event Action<float, float> OnHealthChanged;

        private readonly float _maxHealth;
        
        private float _currentHealth;
        public float CurrentHealth => _currentHealth;

        public Health(HealthDataSo data)
        {
            _maxHealth = data.MaxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        public void Heal(IPickable pickable)
        {
            if(_currentHealth == _maxHealth) return;

            _currentHealth = Math.Min(_currentHealth + pickable.Amount, _maxHealth);
            pickable.Consume();

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }

}
