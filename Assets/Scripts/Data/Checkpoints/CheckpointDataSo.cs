using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "CheckpointDataSo", menuName = "Scriptable Objects/CheckpointDataSo")]
    public class CheckpointDataSo : ScriptableObject
    {
        [SerializeField] private string _checkpointUsedAnimation;
        public int CheckpointUsedAnimationHash => Animator.StringToHash(_checkpointUsedAnimation);

        [SerializeField] private float _displayDelay;
        public float DisplayDelay => _displayDelay;

        [SerializeField] private int _displayTimes;
        public int DisplayTimes => _displayTimes;
    }
}
