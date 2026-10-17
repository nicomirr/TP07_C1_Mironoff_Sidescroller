using UnityEngine;

namespace Game.Enemy
{
    public class EnemyAwarenessController : MonoBehaviour
    {
        [SerializeField] private EnemyTargetDetectorDataSo _data;

        private TargetDetector _targetDetector;

        private void Awake()
        {
            _targetDetector = new TargetDetector(_data, this.transform);
        }

        public bool HasDetectedTarget()
        {
             return _targetDetector.HasDetectedTarget();
        }

        public void ResetTargetDetection()
        {
            _targetDetector.ResetTargetDetection();
        }
    }
}
