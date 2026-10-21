using UnityEngine;
using Game.Data;

public class EnemyParabolicJump : EnemyJump
{
    private readonly float _horizontalJumpForce;

    public EnemyParabolicJump(EnemyParabolicJumpDataSo data, Rigidbody2D rb, Transform enemyTransform) : 
        base(rb, enemyTransform, data.VerticalJumpForce) 
    { 
        _horizontalJumpForce = data.HorizontalJumpForce;
    }    

    public override bool Jump()
    {
        float direction = _enemyTransform.right.x > 0 ? 1 : -1;

        _rb.linearVelocity = new Vector2(_horizontalJumpForce * direction, _verticalJumpForce);

        return true;
    }
   
}
