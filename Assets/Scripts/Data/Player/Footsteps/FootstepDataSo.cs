using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "FootstepDataSo", menuName = "Scriptable Objects/FootstepDataSo")]
    public class FootstepDataSo : ScriptableObject
    {
        [SerializeField] private SurfaceType _surfaceType;
        public SurfaceType SurfaceType => _surfaceType;

        [SerializeField] private AudioClip _audioClip;
        public AudioClip AudioClip => _audioClip;
    }
}
