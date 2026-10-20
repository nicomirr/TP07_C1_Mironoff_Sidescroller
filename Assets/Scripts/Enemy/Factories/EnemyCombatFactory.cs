#nullable enable

using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Enemy;

public class EnemyCombatFactory
{
    public static EnemyAttack? CreateAttack(EnemyAttackDataSo data, Transform enemyTransform, ICoroutineRunner coroutineRunner,
        Transform parent)
    {
        return data.AttackType switch
        {
            EnemyAttackType.RangeDownwards => new EnemyRangedDownwardsAttack((EnemyRangedDownwardsAttackDataSo)data, enemyTransform, coroutineRunner,
            parent),

            _ => null
        };
    }
}
