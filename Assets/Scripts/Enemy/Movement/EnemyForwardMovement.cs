using UnityEngine;
using Game.Data;

namespace Game.Enemy
{
    public class EnemyForwardMovement : EnemyMovement
    {
        public EnemyForwardMovement(EnemyMovementDataSo data, Rigidbody2D rb, Transform enemyTransform) : base(data.MovementSpeed, rb, enemyTransform) { }
        public override void Move()
        {            
            _rb.linearVelocity = new Vector2(_movementSpeed * _enemyTransform.right.x, _rb.linearVelocity.y);
        }                 
    }
}
