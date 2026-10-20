using UnityEngine;
using Game.Data;
using Game.Core;
using System.Collections;

namespace Game.Collectibles
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private CollectibleDataSo _data;
        public CollectibleType CollectibleType => _data.CollectibleType;

        private SpriteRenderer _spriteRenderer;

        private Collider2D _collider;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            _collider = GetComponent<Collider2D>();
        }

        public void Collect()
        {
            _spriteRenderer.enabled = false;
            _collider.enabled = false;

            StartCoroutine(CollectRoutine());
        }

        private IEnumerator CollectRoutine()
        {
            _audioSource.Play();

            yield return new WaitForSeconds(_audioSource.clip.length);

            this.gameObject.SetActive(false);
        }
    }
}

