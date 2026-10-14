using UnityEngine;

namespace Game.Player
{
    public class PlayerFacing
    {
        private Transform _ownerTransform;

        private bool _isFacingRight;
        public bool IsFacingRight => _isFacingRight;

        public PlayerFacing(Transform ownerTransform, bool isFacingRight)
        {
            _ownerTransform = ownerTransform;
            _isFacingRight = isFacingRight;
        }

        public void Flip(float direction)
        {
            if (direction == 0) return;

            _isFacingRight = direction > 0;

            _ownerTransform.right = _isFacingRight ? Vector3.right : Vector3.left;
        }
    }
}
