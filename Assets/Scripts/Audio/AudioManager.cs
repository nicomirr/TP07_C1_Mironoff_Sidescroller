using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

namespace Game.Audio
{
    public class AudioManager : MonoBehaviour
    {        
        [SerializeField] private AudioMixer _audioMixer;                   

        private void ChangeVolume(List<string> groups, float volume)
        {
            foreach (string group in groups)
            {
                float finalVolume = Mathf.Clamp(Mathf.Log10(volume) * 30, -80, 0);
                _audioMixer.SetFloat(group, finalVolume);
            }
        }
    }
}
