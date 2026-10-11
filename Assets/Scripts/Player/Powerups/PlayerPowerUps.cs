using System.Collections.Generic;
using Game.Core;

namespace Game.Player
{
    public class PlayerPowerUps
    {       
        private readonly Dictionary<PowerUpType, PlayerPowerUp> _powerUps = new();
                
        public void AddPowerUp(PowerUpType powerUpType, PlayerPowerUp powerUp)
        {
            _powerUps[powerUpType] = powerUp;
        }

        public void TryEnablePowerUp(PowerUpType powerUpType)
        {
            bool powerUpEnabled = _powerUps[powerUpType].TryEnablePowerUp();
        }
                
    }
}

