using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Pickables;

namespace Game.Player
{
    public class PlayerCollisionHandler
    {
        private readonly IPlayerStateReader _stateReader;
        private readonly PlayerDamageHandler _damageHandler;
        private readonly PlayerPowerUps _playerPowerUps;
        private readonly PlayerPickableEffects _playerPickableEffects;

        public PlayerCollisionHandler(IPlayerStateReader stateReader, PlayerDamageHandler damageHandler,
            PlayerPowerUps playerPowerUps, PlayerPickableEffects playerPickableEffects)
        {
            _stateReader = stateReader;
            _damageHandler = damageHandler;
            _playerPowerUps = playerPowerUps;
            _playerPickableEffects = playerPickableEffects;
        }

        public void HandlePowerUpsCollision(PowerUpDataSo data)
        {
            _playerPowerUps.EnablePowerUp(data);
        }

        public void HandlePickableCollision(IPickable pickable)
        {
            _playerPickableEffects.Consume(pickable);
        }        

        public void HandleDamageCollision(GameObject enemyObject, IDamageProvider damageProvider, float damageDirection)
        {
            if (_stateReader.CurrentState == PlayerState.Invincible)
            {
                DestroyDamageCollided(enemyObject);
                return;
            }

            _damageHandler.TryDamage(damageProvider.Damage, damageDirection);
        }

        private void DestroyDamageCollided(GameObject enemy)
        {            
            enemy.SetActive(false);
        }
    }

}
