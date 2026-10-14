#nullable enable

using UnityEngine;
using Game.Data;

namespace Game.Enemy
{
    public class EnemyLocomotionController : MonoBehaviour
    {
        [SerializeField] private EnemyLocomotionDataSo _data;

        private EnemyMovement? _movement;
        private EnemyFacing _facing;

        private void Awake()
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            _movement = EnemyLocomotionFactory.CreateMovement(_data.MovementData, rb, this.transform);

            _facing = new EnemyFacing(this.transform);
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
        
    }
}

