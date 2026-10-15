#nullable enable

using UnityEngine;
using System.Collections;
using Game.Data;
using Game.Core;

namespace Game.Enemy
{
    public class EnemyLocomotionController : MonoBehaviour, ICoroutineRunner, ICoroutineStopper
    {
        [SerializeField] private EnemyLocomotionDataSo _data;

        private EnemyMovement? _movement;
        private EnemyFacing _facing;

        private void Awake()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            _movement = EnemyLocomotionFactory.CreateMovement(_data.MovementData, rb, this.transform, this, this);

            _facing = new EnemyFacing(this.transform);
        }

        private void OnDisable()
        {
            if (_movement is IDisableable disableable)            
                disableable.Disable();            
        }

        public void Move()
        {
            _movement?.Move();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<DirectionChanger>(out _))
            {
                _facing.Flip();
            }
        }

        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void FinalizeCoroutine(Coroutine routine)
        {
            StopCoroutine(routine);
        }
    }
}

