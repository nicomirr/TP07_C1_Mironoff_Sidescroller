using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParallaxDataSo", menuName = "Scriptable Objects/ParallaxDataSo")]
    public class ParallaxDataSo : ScriptableObject
    {
        [SerializeField, Range(0f, 1f)] private float _parallaxX;
        public float ParallaxX => _parallaxX;

        [SerializeField, Range(0f, 1f)] private float _parallaxY;
        public float ParallaxY => _parallaxY;
    }

}

