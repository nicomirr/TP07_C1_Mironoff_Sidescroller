using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BoatDataSo", menuName = "Scriptable Objects/BoatDataSo")]
    public class BoatDataSo : ScriptableObject
    {
        [SerializeField, Range(0.05f, 0.2f)] private float _bobbingAmplitude;
        public float BobbingAmplitude => _bobbingAmplitude;

        [SerializeField, Range(1f, 3f)] private float _bobbingSpeed;
        public float BobbingSpeed => _bobbingSpeed;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

    }
}

