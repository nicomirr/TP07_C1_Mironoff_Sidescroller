using UnityEngine;
using Game.Data;

namespace Game.Player
{
    public class PlayerKnockback
    {
        private readonly Rigidbody2D _rb;
        
        private readonly float _horizontalKnockbackForce;
        private readonly float _verticalKnockbackForce;

        public PlayerKnockback(PlayerConfigSo data, Rigidbody2D rb)
        {
            _rb = rb;

            _horizontalKnockbackForce = data.KnockbackData.HorizontalKnockbackForce;
            _verticalKnockbackForce = data.KnockbackData .VerticalKnockbackForce;   
        }

        public void ApplyKnockback(float direction)
        {
            _rb.linearVelocityY = 0f;

            Vector2 force = new Vector2(Mathf.Sign(direction) * _horizontalKnockbackForce, _verticalKnockbackForce);
            _rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}

