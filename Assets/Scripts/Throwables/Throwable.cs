using UnityEngine;
using Game.Data;
using Game.Core;
using Game.ParticleEffects;

namespace Game.Throwables
{
    public class Throwable : MonoBehaviour, IDamageProvider
    {
        [SerializeField] private ThrowableDataSo _data;
        public float ContactDamage => _data.Damage;

        private Rigidbody2D _rb;
        private Collider2D _collider;

        private float _throwableTimer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            _throwableTimer = 0;
        }

        private void Update()
        {
            _throwableTimer += Time.deltaTime;

            if (_throwableTimer >= _data.LifeTime)
                this.gameObject.SetActive(false);

        }

        public void Throw(Vector2 startingPos, float direction, Vector2 throwerVelocity)
        {
            this.transform.position = startingPos;

            _rb.linearVelocity = new Vector2(throwerVelocity.x + (Mathf.Sign(direction) * _data.HorizontalSpeed), _data.VerticalSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 collisionPoint = collision.GetContact(0).point;

            CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.RockImpact, collisionPoint));

            gameObject.SetActive(false);
        }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    ColliderDistance2D distance = _collider.Distance(collision);

        //    Vector2 impactPoint = distance.pointB;

        //    CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.RockImpact, impactPoint));

        //    gameObject.SetActive(false);
        //}
    }
}
