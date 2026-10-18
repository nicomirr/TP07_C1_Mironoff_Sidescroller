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

            _audioSource.clip = _footsteps[surfaceType];

            _audioSource.Play();
        }
    } 
}

