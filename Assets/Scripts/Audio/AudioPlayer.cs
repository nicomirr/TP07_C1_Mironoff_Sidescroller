using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Audio
{
    public class AudioPlayer
    {       
        private AudioSource _audioSource;
        private Dictionary<AudioCategory, AudioClip> _audios;

        public AudioPlayer(AudioConfigSo data, AudioSource audioSource)
        {
            _audioSource = audioSource;

            _audios = new Dictionary<AudioCategory, AudioClip>();

            foreach (AudioDataSo audioData in data.Audios)
            {
                _audios.Add(audioData.AudioCategory, audioData.AudioClip);
            }
        }

        public void PlayAudio(AudioCategory category)
        {
            // Warning: Si el AudioConfigSo no tiene esa categoría (por ejemplo, JumpSFX en GreenSlimeAudioConfig) esto lanza KeyNotFoundException.
            // Usá _audios.TryGetValue(category, out AudioClip clip) y logueá una advertencia si falta.
            _audioSource.PlayOneShot(_audios[category]);
        }
    }
}

