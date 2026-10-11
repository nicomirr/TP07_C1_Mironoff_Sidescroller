using Game.AnimationSystem;
using Game.Core;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerAnimations
    {
        private readonly AnimationHandler _animationHandler;

        public PlayerAnimations(AnimationHandler animationHandler)
        {
            _animationHandler = animationHandler;
        }

        public void SetPlayerDirection(float value)
        {
            _animationHandler.SetFloat(AnimationType.PlayerDirection, value);
        }

        public void SetThrowMovement(float value)
        {
            _animationHandler.SetFloat(AnimationType.PlayerThrowMovement, value);
        }

        public void SetMoveAnimation(bool value)
        {
            _animationHandler.SetBool(AnimationType.PlayerIsMoving, value);
        }

        public void SetJumpAnimation(bool value)
        {
            _animationHandler.SetBool(AnimationType.PlayerIsJumping, value);
        }

        public void SetThrowAnimation(bool value)
        {
            _animationHandler.SetBool(AnimationType.PlayerIsThrowing, value);
        }

    }

}

