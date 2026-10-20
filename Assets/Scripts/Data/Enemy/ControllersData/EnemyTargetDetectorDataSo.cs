using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTargetDetectorDataSo", menuName = "Scriptable Objects/EnemyTargetDetectorDataSo")]
public class EnemyTargetDetectorDataSo : ScriptableObject
{
    [SerializeField] private float _detectionRadius;
    public float DetectionRadius => _detectionRadius;

    [SerializeField] private float _facingRadius;
    public float FacingRadius => _facingRadius;

    [SerializeField] private float _detectionWidth;
    public float DetectionWidth => _detectionWidth;

    [SerializeField] private LayerMask _targetLayer;
    public LayerMask TargetLayer => _targetLayer;
}
