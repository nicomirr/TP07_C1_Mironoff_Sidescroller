using UnityEngine;
using System;
using Game.Data;

namespace Game.Common
{
    public class Health  
    {
        public event Action<float, float> OnHealthChanged;

        protected readonly float _maxHealth;
        
        protected float _currentHealth;
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

        protected void RaiseHealthChanged()
        {
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
        public void RestoreHealth()
        {
            _currentHealth = _maxHealth;
            RaiseHealthChanged();
        }
    }
}
