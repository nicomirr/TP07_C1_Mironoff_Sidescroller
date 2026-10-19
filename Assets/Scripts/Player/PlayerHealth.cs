using System;
using Game.Data;
using Game.Common;

namespace Game.Player
{
    public class PlayerHealth : Health, IHealable
    {
        public PlayerHealth(HealthDataSo data) : base(data) { }

        public void Heal(float amount)
        {
            if (_currentHealth == _maxHealth) return;

            _currentHealth = Math.Min(_currentHealth + amount, _maxHealth);
            
            RaiseHealthChanged();
        }        
    }
}
