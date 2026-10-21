using UnityEngine;

public abstract class EnemyJump
{
    protected readonly Rigidbody2D _rb;
    protected readonly Transform _enemyTransform;
    protected readonly float _verticalJumpForce;

    public EnemyJump(Rigidbody2D rb, Transform enemyTransform, float verticalJumpForce)
    {
        _rb = rb;
        _enemyTransform = enemyTransform;
        _verticalJumpForce = verticalJumpForce;
    }

    public abstract bool Jump();
}
