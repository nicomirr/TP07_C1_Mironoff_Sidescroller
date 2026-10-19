using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerDollDataSo", menuName = "Scriptable Objects/PlayerDollDataSo")]
    public class PlayerDollDataSo : ScriptableObject
    {
        [SerializeField] private string _leftDeathAnimation;
        public int LeftDeathAnimationHash => Animator.StringToHash(_leftDeathAnimation);

        [SerializeField] private string _rightDeathAnimation;
        public int RightDeathAnimationHash => Animator.StringToHash(_rightDeathAnimation);
    }

}

