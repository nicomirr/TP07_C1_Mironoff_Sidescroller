using UnityEngine;

namespace Game.ParticleEffects
{
    public class ParticleEffect : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _audioSource.Play();
        }
    }

}
