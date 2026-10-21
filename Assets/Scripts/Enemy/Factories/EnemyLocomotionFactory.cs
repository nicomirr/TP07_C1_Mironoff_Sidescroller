#nullable enable

using UnityEngine;
using Game.Core;
using Game.Data;

namespace Game.Enemy
{
    public static class EnemyLocomotionFactory
    {
        public static EnemyMovement? CreateMovement(EnemyMovementDataSo data, Rigidbody2D rb, Transform enemyTransform, 
            ICoroutineRunner coroutineRunner, ICoroutineStopper coroutineStopper)
        {
            return data.MovementType switch
            {
                EnemyMovementType.Forward => new EnemyForwardMovement(data, rb, enemyTransform),

                EnemyMovementType.ForwardDash => new EnemyDashMovement((EnemyDashMovementDataSo)data, rb, enemyTransform, coroutineRunner, coroutineStopper),

                _ => null
            };
        }

        public static EnemyJump? CreateJump(EnemyJumpDataSo data, Rigidbody2D rb, Transform enemyTransform, ICoroutineRunner coroutineRunner)
        {
            return data.JumpType switch
            {
                EnemyJumpType.ParabolicJump => new EnemyParabolicJump((EnemyParabolicJumpDataSo)data, rb, enemyTransform),

                EnemyJumpType.LinearJump => new EnemyLinearJump((EnemyLinearJumpDataSo)data, rb, enemyTransform, coroutineRunner),

                _ => null
            };
        }
    }

}
