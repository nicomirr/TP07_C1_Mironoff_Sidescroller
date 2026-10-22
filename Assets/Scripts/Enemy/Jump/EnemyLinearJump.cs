using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Data;

namespace Game.Enemy
{
    public class EnemyLinearJump : EnemyJump, IReset
    {
        private readonly float _jumpCooldown;

        private ICoroutineRunner _coroutineRunner;

        private Coroutine _cooldownRoutine;

        private bool _canJump;

        public EnemyLinearJump(EnemyLinearJumpDataSo data, Rigidbody2D rb, Transform enemyTransform, ICoroutineRunner coroutineRunner) 
            : base(rb, enemyTransform, data.VerticalJumpForce)
        {
            _jumpCooldown = data.JumpCooldown;
            _coroutineRunner = coroutineRunner;

            _canJump = true;
        }

        public override bool Jump()
        {
            if (!_canJump) return false;

            _rb.AddForce(Vector2.up * _verticalJumpForce, ForceMode2D.Impulse);
            _canJump = false;

            if(_cooldownRoutine != null)            
                _cooldownRoutine = null;

            _cooldownRoutine = _coroutineRunner.RunCoroutine(CooldownRoutine());

            return true;
        }        

        private IEnumerator CooldownRoutine()
        {
            yield return new WaitForSeconds(_jumpCooldown);

            _canJump = true;
        }

        public void ResetObject()
        {
            _canJump = true;
        }
    }
}


