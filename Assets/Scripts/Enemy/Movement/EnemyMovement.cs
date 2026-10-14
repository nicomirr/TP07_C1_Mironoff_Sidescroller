using UnityEngine;

namespace Game.Enemy
{
    public abstract class EnemyMovement
    {
        protected readonly float _movementSpeed;
        protected readonly Rigidbody2D _rb;
        protected readonly Transform _enemyTransform;

        public EnemyMovement(float movementSpeed, Rigidbody2D rb, Transform enemyTransform)
        {
            _movementSpeed = movementSpeed;
            _rb = rb;
            _enemyTransform = enemyTransform;
        }

        public abstract void Move();        
    }
}
