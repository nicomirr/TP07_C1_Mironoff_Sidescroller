using UnityEngine;
using Game.Core;

namespace Game.Surface
{
    public class SurfaceIdentifier : MonoBehaviour
    {
        [SerializeField] private SurfaceType _surfaceType;
        public SurfaceType SurfaceType => _surfaceType;
    }

}
