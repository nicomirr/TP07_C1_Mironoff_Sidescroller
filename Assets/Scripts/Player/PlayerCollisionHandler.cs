using UnityEngine;
using Game.Core;

namespace Game.Player
{
    public class PlayerCollisionHandler
    {
        private readonly IPlayerStateReader _stateReader;
        private readonly PlayerDamageHandler _damageHandler;
        private readonly PickableHandler _pickableHandler;

        public PlayerCollisionHandler(IPlayerStateReader stateReader, PlayerDamageHandler damageHandler, PickableHandler pickableHandler)
        {
            _stateReader = stateReader;
            _damageHandler = damageHandler;
            _pickableHandler = pickableHandler;
        }

        public void HandlePickableCollision(IPickable pickable)
        {
            _pickableHandler.NotifyPickable(pickable);
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
