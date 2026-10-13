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

        protected override void Awake()
        {
            base.Awake();

            _health = new Health(_slimeData.HealthData);

            TargetDetector targetDetector = new TargetDetector(_targetDetectorData, this.transform);

            _forwardMovement = new EnemyForwardMovement(_slimeData.MovementData, GetComponent<Rigidbody2D>(), targetDetector);
        }

        private void Start()
        {
            _contactDamage = _slimeData.ContactDamage;
        }

        private void FixedUpdate()
        {
            _forwardMovement.Move();
        }
    }
}
