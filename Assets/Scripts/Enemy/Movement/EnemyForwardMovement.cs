using Game.Data;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyForwardMovement : EnemyMovement
    {
        private readonly TargetDetector _targetDetector;

        public EnemyForwardMovement(EnemyMovementDataSo data, Rigidbody2D rb, TargetDetector targetDetector) : base(data.MovementSpeed, rb)
        {
            _targetDetector = targetDetector;
        }

        public override void Move()
        {
            if (!_targetDetector.HasDetectedTarget()) return;

            _rb.linearVelocity = new Vector2(-_movementSpeed, _rb.linearVelocity.y);
        }
    }
}
