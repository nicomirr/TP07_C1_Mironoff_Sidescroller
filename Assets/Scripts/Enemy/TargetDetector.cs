//#nullable enable
using UnityEngine;

namespace Game.Enemy
{
    public class TargetDetector
    {
        private readonly float _detectionRadius;
        private readonly LayerMask _targetLayer;
        private readonly Transform _ownerTransform;

        private bool _targetDetected;

        //private Transform? _targetTransform;

        public TargetDetector(EnemyTargetDetectorDataSo data, Transform ownerTransform)
        {
            _detectionRadius = data.DetectionRadius;
            _targetLayer = data.TargetLayer;
            _ownerTransform = ownerTransform;

            //_targetTransform = null;
        }

        public bool HasDetectedTarget()
        {
            if(_targetDetected ) return true;

            Collider2D detected = Physics2D.OverlapCircle(_ownerTransform.position, _detectionRadius,
                _targetLayer);                       

            if (detected == null) return false;

            _targetDetected = true;

            //_targetTransform = detected.transform;
            
            return true;            
        }

        //public Transform? GetTargetTransform()
        //{
        //    if(_targetTransform == null)
        //    {
        //        Debug.LogError("Error. El transform del target no deberia ser null cuando se lo quiere adquirir.", _ownerTransform);
        //        return null;
        //    }

        //    return _targetTransform;
        //}
    }

}
