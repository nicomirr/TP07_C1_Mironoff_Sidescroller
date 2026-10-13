using UnityEngine;

namespace Game.Enemy
{
    public class TargetDetector
    {
        private readonly float _detectionRadius;
        private readonly LayerMask _targetLayer;
        private readonly Transform _ownerTransform;

        private bool _targetDetected;

        public TargetDetector(EnemyTargetDetectorDataSo data, Transform ownerTransform)
        {
            _detectionRadius = data.DetectionRadius;
            _targetLayer = data.TargetLayer;
            _ownerTransform = ownerTransform;
        }

        public bool HasDetectedTarget()
        {
            if(_targetDetected ) return true;

            Collider2D detected = Physics2D.OverlapCircle(_ownerTransform.position, _detectionRadius,
                _targetLayer);

            if (detected == null) return false;

            _targetDetected = true;
            return true;            
        }

    }

}
