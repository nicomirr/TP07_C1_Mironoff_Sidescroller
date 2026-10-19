using UnityEngine;

namespace Game.Enemy
{
    public class TargetDetector
    {
        private readonly float _detectionRadius;
        private readonly float _facingRadius;

        private readonly LayerMask _targetLayer;
        private readonly Transform _ownerTransform;

        private bool _targetDetected;
        private bool _facingTarget;

        public TargetDetector(EnemyTargetDetectorDataSo data, Transform ownerTransform)
        {
            _detectionRadius = data.DetectionRadius;
            _facingRadius = data.FacingRadius;

            _targetLayer = data.TargetLayer;
            _ownerTransform = ownerTransform;
        }

        public void FaceTarget()
        {
            if (_facingTarget) return;

            Collider2D detected = Physics2D.OverlapCircle(_ownerTransform.position, _facingRadius,
                _targetLayer);

            if (detected == null) return;

            _ownerTransform.right = detected.transform.position.x < _ownerTransform.position.x ? Vector2.left : 
                Vector2.right;  

            _facingTarget = true;
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

        public void ResetTargetDetection()
        {
            _targetDetected = false;
            _facingTarget = false;
        }
    }

}
