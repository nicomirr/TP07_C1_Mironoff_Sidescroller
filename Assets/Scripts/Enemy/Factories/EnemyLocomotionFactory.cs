#nullable enable

using UnityEngine;
using Game.Core;
using Game.Data;

namespace Game.Enemy
{
    public static class EnemyLocomotionFactory
    {
        public static EnemyMovement? CreateMovement(EnemyMovementDataSo data, Rigidbody2D rb, Transform enemyTransform)
        {
            return data.MovementType switch
            {
                EnemyMovementType.Forward => new EnemyForwardMovement(data, rb, enemyTransform),
                _ => null
            };
        }
    }

}
