using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Marker;
using Game.Data;

namespace Game.Enemy
{
    public class EnemyBullet : MonoBehaviour, IDamageProvider
    {
        [SerializeField] private EnemyBulletDataSo _data;

        private Rigidbody2D _rb;
        public float Damage => _data.Damage;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {            
            StartCoroutine(DespawnRoutine());
        }

        private void OnDisable()
        {
            _rb.linearVelocity = Vector2.zero;
        }

        public void SetDirection(Vector2 direction)
        {
            _rb.linearVelocity = direction.normalized * _data.Speed;
        }

        private IEnumerator DespawnRoutine()
        {
            yield return new WaitForSeconds(_data.Lifetime);

            this.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerMarker _))
                this.gameObject.SetActive(false);
        }
    }

}
