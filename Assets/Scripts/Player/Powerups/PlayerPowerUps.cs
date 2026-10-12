using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Player
{
    public class PlayerPowerUps
    {       
        private readonly Dictionary<PowerUpType, PlayerPowerUp> _powerUps = new();
                
        public void AddPowerUp(PowerUpType powerUpType, PlayerPowerUp powerUp)
        {
            _powerUps[powerUpType] = powerUp;
        }

        public void EnablePowerUp(PowerUpDataSo data)
        {
            _powerUps[data.PowerUpType].EnablePowerUp(data);
        }
                
    }
}

