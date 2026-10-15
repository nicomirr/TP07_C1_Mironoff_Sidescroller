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
            Vector3 cameraDelta = Camera.main.transform.position - _lastCameraPosition;

            this.transform.position += new Vector3(cameraDelta.x * _data.ParallaxX, cameraDelta.y * _data.ParallaxY, 0f);

            _lastCameraPosition = Camera.main.transform.position;
        }
    }
}
