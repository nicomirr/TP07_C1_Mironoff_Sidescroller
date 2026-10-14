using UnityEngine;

namespace Game.Common
{
    public class Facing
    {
        private Transform _transform;

        private bool _isFacingRight;
        public bool IsFacingRight => _isFacingRight;

        public Facing(Transform playerTransform, bool isFacingRight)
        {
            _transform = playerTransform;
            _isFacingRight = isFacingRight;
        }

        public void Flip(float direction)
        {
            if (direction == 0) return;

            _isFacingRight = direction > 0;

            _transform.right = _isFacingRight ? Vector3.right : Vector3.left;
        }
    }
}
