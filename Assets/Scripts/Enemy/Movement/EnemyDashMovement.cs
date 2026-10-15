using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Data;

namespace Game.Enemy
{
    public class EnemyDashMovement : EnemyMovement, IDisableable
    {
        private readonly EnemyDashMovementDataSo _data;

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ICoroutineStopper _coroutineStopper;

        private Coroutine _moveRoutine;

        private float _currentSpeed;
        private bool _coroutineActive;

        public EnemyDashMovement(EnemyDashMovementDataSo data, Rigidbody2D rb, Transform enemyTransform,
            ICoroutineRunner coroutineRunner, ICoroutineStopper coroutineStopper) : base(data.MovementSpeed, rb, enemyTransform)
        {
            _data = data;

            _coroutineRunner = coroutineRunner;
            _coroutineStopper = coroutineStopper;
        }

        public override void Move()
        {
            _rb.linearVelocity = new Vector2(_currentSpeed * _enemyTransform.right.x, _rb.linearVelocity.y);

            if (_moveRoutine != null) return;

            _moveRoutine = _coroutineRunner.RunCoroutine(DashRoutine());
            _coroutineActive = true;
        }

        private IEnumerator DashRoutine()
        {
            while (_coroutineActive)
            {
                _currentSpeed = _movementSpeed;

                float delayTime = Mathf.Round(Random.Range(_data.MinDelayTime, _data.MaxDelayTime) * 10f) * 0.1f;

                yield return new WaitForSeconds(delayTime);

                _currentSpeed = 0;

                yield return new WaitForSeconds(_data.WaitTime);

                _currentSpeed = _movementSpeed * _data.SpeedMultiplier;

                yield return new WaitForSeconds(_data.DashTime);
            }            
        }

        private void StopRoutine()
        {
            if (_moveRoutine == null) return;

            _coroutineActive = false;
            _coroutineStopper.FinalizeCoroutine(_moveRoutine);
            _moveRoutine = null;
        }

        public void Disable()
        {
            StopRoutine();
        }
    }
}
