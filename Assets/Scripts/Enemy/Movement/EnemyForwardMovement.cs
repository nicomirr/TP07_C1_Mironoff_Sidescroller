using UnityEngine;
using Game.Data;

namespace Game.Enemy
{
    public class EnemyForwardMovement : EnemyMovement
    {
        private readonly TargetDetector _targetDetector;

        private int _direction;
        public int Direction => _direction;

        public EnemyForwardMovement(EnemyMovementDataSo data, Rigidbody2D rb, TargetDetector targetDetector) : base(data.MovementSpeed, rb)
        {
            _targetDetector = targetDetector;
            _direction = -1;
        }

        public override void Move()
        {
            if (!_targetDetector.HasDetectedTarget()) return;

            _rb.linearVelocity = new Vector2(_movementSpeed * _direction, _rb.linearVelocity.y);
        }

        public void ToggleDirection()
        {
            _direction *= -1;
        }       
    }
}
