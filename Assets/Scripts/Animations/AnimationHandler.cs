using UnityEngine;
using Game.Core;

namespace Game.AnimationSystem
{
    public class AnimationHandler
    {
        private readonly Animator _animator;
        private readonly AnimationLibrary _animationLibrary;

        public AnimationHandler(Animator animator, AnimationLibrary animationLibrary)
        {
            _animator = animator;
            _animationLibrary = animationLibrary;
        }

        public void SetFloat(AnimationType animationType, float value)
        {
            bool animationFound = _animationLibrary.TryGetHash(animationType, out int hash);

            if (!animationFound) return;

            // Warning: Comparación de floats con ==. Usá Mathf.Approximately(value, _animator.GetFloat(hash)).
            if (value == _animator.GetFloat(hash)) return;

            _animator.SetFloat(hash, value);
        }

        public void SetBool(AnimationType animationType, bool state)
        {
            bool animationFound = _animationLibrary.TryGetHash(animationType, out int hash);

            if (!animationFound) return;

            if (state == _animator.GetBool(hash)) return;

            _animator.SetBool(hash, state);
        }

      
    }

}

