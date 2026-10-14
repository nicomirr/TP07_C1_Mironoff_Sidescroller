using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{    
    [SerializeField, Range(0f, 1f)]
    private float _parallaxX = 0.1f;

    [SerializeField, Range(0f, 1f)]
    private float _parallaxY = 0.05f;

    private Vector3 _lastCameraPosition;

    private void Start()
    {
        _lastCameraPosition = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 cameraDelta = Camera.main.transform.position - _lastCameraPosition;

        this.transform.position += new Vector3(cameraDelta.x * _parallaxX, cameraDelta.y * _parallaxY, 0f);

        _lastCameraPosition = Camera.main.transform.position;
    }
}