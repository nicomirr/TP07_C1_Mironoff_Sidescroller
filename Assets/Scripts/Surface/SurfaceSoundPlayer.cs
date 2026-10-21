using Game.Marker;
using UnityEngine;

namespace Game.Surface
{
    public class SurfaceSoundPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out ThrowableMarker _)) return;

            _audioSource.Play();
        }
    }
}


