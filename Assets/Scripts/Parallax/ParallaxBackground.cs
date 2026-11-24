using UnityEngine;
using Game.Data;

namespace Game.Parallax
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private ParallaxDataSo _data;

        private Vector3 _lastCameraPosition;

        private void Start()
        {
            _lastCameraPosition = Camera.main.transform.position;
        }

        private void LateUpdate()
        {
            // Warning: Camera.main se consulta dos veces por frame en LateUpdate. Cacheá el Transform de la cámara en Awake o Start.
            Vector3 cameraDelta = Camera.main.transform.position - _lastCameraPosition;

            this.transform.position += new Vector3(cameraDelta.x * _data.ParallaxX, cameraDelta.y * _data.ParallaxY, 0f);

            _lastCameraPosition = Camera.main.transform.position;
        }
    }
}
