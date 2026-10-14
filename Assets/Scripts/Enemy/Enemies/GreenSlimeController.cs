using UnityEngine;
using Game.Data;
using Game.Common;

namespace Game.Enemy
{
    public class GreenSlimeController : EnemyController
    {
        [SerializeField] private GreenSlimeDataSo _slimeData;
        [SerializeField] private EnemyTargetDetectorDataSo _targetDetectorData;

        private EnemyForwardMovement _forwardMovement;
        private Facing _enemyFacing;

        protected override void Awake()
        {
            base.Awake();

            _health = new Health(_slimeData.HealthData);

            TargetDetector targetDetector = new TargetDetector(_targetDetectorData, this.transform);
            _forwardMovement = new EnemyForwardMovement(_slimeData.MovementData, GetComponent<Rigidbody2D>(), targetDetector);

            _enemyFacing = new Facing(this.transform, false);
        }

        private void Start()
        {
            _contactDamage = _slimeData.ContactDamage;
        }

        private void FixedUpdate()
        {
            _forwardMovement.Move();
        }

        private void HandleDirectionChange()
        {
            _forwardMovement.ToggleDirection();
            _enemyFacing.Flip(_forwardMovement.Direction);
            
        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);

            if (!collision.gameObject.TryGetComponent<DirectionChanger>(out _)) return;

            HandleDirectionChange();
        }
    }
}
