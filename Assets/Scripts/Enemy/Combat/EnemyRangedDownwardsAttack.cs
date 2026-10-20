using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Enemy
{
    public class EnemyRangedDownwardsAttack : EnemyAttack
    {
        private readonly List<EnemyBullet> _bullets = new();

        public EnemyRangedDownwardsAttack(EnemyRangedDownwardsAttackDataSo data, Transform enemyTransform, ICoroutineRunner coroutineRunner,
            Transform bulletsTransform) :
            base(data.Cooldown, enemyTransform, coroutineRunner)
        {
            for (int i = 0; i < data.BulletAmount; i++)
            {
                EnemyBullet bullet = GameObject.Instantiate(data.BulletPrefab, bulletsTransform).GetComponent<EnemyBullet>();
                bullet.gameObject.SetActive(false);

                _bullets.Add(bullet);
            }

            _canAttack = true;
        }

        public override void Attack()
        {
            _canAttack = false;

            FireBullet();

            _coroutineRunner.RunCoroutine(CooldownRoutine());
        }

        private void FireBullet()
        {
            foreach (EnemyBullet bullet in _bullets)
            {
                if(!bullet.gameObject.activeSelf)
                {
                    bullet.gameObject.transform.position = _enemyTransform.position;
                    bullet.gameObject.SetActive(true);
                    bullet.SetDirection(Vector2.down);
                    return;
                }              
            }

            Debug.LogError("Error. El enemigo deberia tener siempre balas disponibles");
        }
    }

}
