using UnityEngine;
using System.Collections;
using Game.Core;

public abstract class EnemyAttack
{
    protected readonly float _attackCooldown;
    protected readonly Transform _enemyTransform;

    protected readonly ICoroutineRunner _coroutineRunner;

    protected bool _canAttack;
    public bool CanAttack => _canAttack;

    public EnemyAttack(float attackCooldown, Transform enemyTransform, ICoroutineRunner coroutineRunner)
    {
        _attackCooldown = attackCooldown;
        _enemyTransform = enemyTransform;

        _coroutineRunner = coroutineRunner;
    }

    public abstract void Attack();
    
    protected IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(_attackCooldown);

        _canAttack = true;
    }
}
