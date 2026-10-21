using Game.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyJumpDataSo", menuName = "Scriptable Objects/EnemyJumpDataSo")]
public class EnemyJumpDataSo : ScriptableObject
{
    [SerializeField] private EnemyJumpType _jumpType;
    public EnemyJumpType JumpType => _jumpType;

    [SerializeField] private float _verticalJumpForce;
    public float VerticalJumpForce => _verticalJumpForce;

    [SerializeField] private string _jumpAnimation;
    public int JumpAnimationHash => Animator.StringToHash(_jumpAnimation);
}
