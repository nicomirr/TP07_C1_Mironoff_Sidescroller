using UnityEngine;
using Game.Data;
using Game.Core;
using Game.Common;
using Game.UI;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour, IDamageProvider
    {
        [SerializeField] private UIHealth _UIHealth;

        [SerializeField] private EnemyDataSo _data;
        public float Damage => _data.ContactDamage;

        private EnemyMovement _enemyMovement;
        private Health _health;
        private EnemyDeath _enemyDeath;


        private void Awake()
        {
            _enemyMovement = EnemyBehaviourFactory.CreateMovement(_data.MovementData.MovementType, _data.MovementData.MovementSpeed, GetComponent<Rigidbody2D>());
            _health = new Health(_data.HealthData);
            _enemyDeath = new EnemyDeath(this.gameObject);
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += _UIHealth.UpdateHealth;
            _health.OnHealthChanged += _enemyDeath.HandleDeath;
        }

        private void FixedUpdate()
        {
            _enemyMovement.Move();
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= _UIHealth.UpdateHealth;
            _health.OnHealthChanged -= _enemyDeath.HandleDeath;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out IDamageProvider damageProvider))
                return;

            _health.TakeDamage(damageProvider.Damage);
        }

    }

}

