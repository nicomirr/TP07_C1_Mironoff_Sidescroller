using Game.Core;
using Game.Data;
using Game.ParticleEffects;
using UnityEngine;

namespace Game.Management
{
    public class PlayerDeathHandler
    {
        private readonly PlayerDoll _playerDoll;

        public PlayerDeathHandler(GameManagerDataSo data)
        {
           _playerDoll = data.PlayerDollObject.GetComponent<PlayerDoll>();
        }

        public void HandleDeath(bool isWater, float direction, Vector3 position)
        {
            if(isWater)
            {
                CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.WaterImpact, position));
                return;
            }

            PlayerDoll doll = GameObject.Instantiate(_playerDoll, position, Quaternion.identity);
            doll.SetAnimation(direction);            
        }
    }
}

