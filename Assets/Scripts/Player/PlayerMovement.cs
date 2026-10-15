#nullable enable

using Game.Data;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement
    {        
        private readonly Rigidbody2D _rb;
        private readonly float _movementSpeed;

        private IHorizontalVelocityProvider? _velocityProvider;

        public PlayerMovement(Rigidbody2D rb, PlayerConfigSo data)
        {
            _rb = rb;
            _movementSpeed = data.MovementSpeed;
        }

        public void Move(float direction)
        {
            float externalVelocity = _velocityProvider?.HorizontalVelocity ?? 0f;

            _rb.linearVelocity = new Vector2(direction * _movementSpeed, _rb.linearVelocityY);
            _rb.linearVelocityX += externalVelocity;
        }      

        public void SetVelocityProvider(IHorizontalVelocityProvider velocityProvider)
        {
            _velocityProvider = velocityProvider;
        }

        public void ResetVelocityProvider()
        {
            _velocityProvider = null;
        }
    }
}
