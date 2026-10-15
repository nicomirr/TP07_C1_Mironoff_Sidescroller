using UnityEngine;

namespace Game.Enemy
{
    public class EnemyFacing
    {
        private readonly Transform _enemyTransform;

        public EnemyFacing(Transform transform)
        {
            _enemyTransform = transform;
        }        

        public void Flip()
        {
            _enemyTransform.right = _enemyTransform.right.x > 0 ? Vector3.left : Vector3.right;
        }
    }
}

