using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Data;
using Game.Marker;
using Game.ParticleEffects;

namespace Game.Pickables
{
    public class Pickable : MonoBehaviour, IPickable
    {
        [SerializeField] private PickableDataSo _pickableData;
        public PickableDataSo Data => _pickableData;

        private AudioSource _audioSource;

        private Collider2D _collider;
        private SpriteRenderer _spriteRenderer;

        private Coroutine _despawnRoutine;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _collider = GetComponent<Collider2D>();
            _spriteRenderer= GetComponentInChildren<SpriteRenderer>();
        }

        private void OnEnable()
        {
            if(_despawnRoutine != null)
                _despawnRoutine = null;

            _despawnRoutine = StartCoroutine(DespawnRoutine());
        }

        public void Consume()
        {
            StopCoroutine(_despawnRoutine);
            _despawnRoutine = null;
            _collider.enabled = false;

            StartCoroutine(ConsumeRoutine());
        }

        private IEnumerator ConsumeRoutine()
        {
            _audioSource.Play();
            _spriteRenderer.enabled = false;

            yield return new WaitForSeconds(_audioSource.clip.length);

            Destroy(this.gameObject);
        }

        private IEnumerator DespawnRoutine()
        {
            yield return new WaitForSeconds(_pickableData.DespawnTime);
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out WaterMarker _))
            {
                CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.WaterImpact, this.transform.position));
                Destroy(this.gameObject);
            }
        }
    }

}

