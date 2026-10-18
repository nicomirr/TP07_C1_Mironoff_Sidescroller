using UnityEngine;
using Game.Core;

namespace Game.Audio
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseNotifierGameObject;

        private IPauseNotifier _pauseNotifier;

        protected AudioSource _audioSource;

        protected virtual void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnEnable()
        {
            //PlayerEvents.OnPlayerDeath += StopAudio;

            _pauseNotifier.OnGamePaused += PauseAudio;
            _pauseNotifier.OnGameUnpaused += UnpauseAudio;
        }

        protected virtual void OnDisable()
        {
            //PlayerEvents.OnPlayerDeath -= StopAudio;

            _pauseNotifier.OnGamePaused -= PauseAudio;
            _pauseNotifier.OnGameUnpaused -= UnpauseAudio;
        }

        private void UnpauseAudio()
        {
            _audioSource.UnPause();
        }

        private void PauseAudio()
        {
            _audioSource.Pause();
        }

        private void StopAudio()
        {
            _audioSource.Stop();
        }
    }
}

