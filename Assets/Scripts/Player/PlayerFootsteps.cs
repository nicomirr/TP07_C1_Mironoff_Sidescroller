using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Player
{
    public class PlayerFootsteps
    {
        private readonly Dictionary<SurfaceType, AudioClip> _footsteps = new();
        private readonly AudioSource _audioSource;

        public PlayerFootsteps(AudioSource audioSource, PlayerFootstepsDataSo data)
        {
            _audioSource = audioSource;

            foreach(FootstepDataSo footstep in data.FootstepsData)
            {
                _footsteps.Add(footstep.SurfaceType, footstep.AudioClip);
            }
        }

        public void PlayFootsteps(SurfaceType surfaceType)
        {
            if (_audioSource.isPlaying) return;

            // Warning: Indexar el diccionario sin TryGetValue lanza KeyNotFoundException si el jugador pisa un suelo sin SurfaceIdentifier
            // (queda el SurfaceType por defecto) o con un tipo que no está en PlayerFootstepsData. Usá TryGetValue y salí si no existe.
            _audioSource.clip = _footsteps[surfaceType];

            _audioSource.Play();
        }
    } 
}

