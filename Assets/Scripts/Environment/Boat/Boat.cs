using UnityEngine;
using Game.Data;
using Game.Marker;
using Game.Core;

public class Boat : MonoBehaviour, IHorizontalVelocityProvider
{
    [SerializeField] private BoatDataSo _data;

    private Rigidbody2D _rb;

    public float HorizontalVelocity => _rb.linearVelocityX;

    private bool _movementEnabled;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {       
        _movementEnabled = false;
    }

    private void FixedUpdate()
    {
        ApplyBobbingMotion();
        Move();
    }

    private void ApplyBobbingMotion()
    {
        float verticalSpeed = Mathf.Cos(Time.time * _data.BobbingSpeed) * _data.BobbingAmplitude * 
            _data.BobbingSpeed;  
        
        _rb.linearVelocityY = verticalSpeed;
    } 

    private void Move()
    {
        if (!_movementEnabled)
        {
            _rb.linearVelocityX = 0;
            return;
        }

        _rb.linearVelocityX = _data.MovementSpeed * this.transform.right.x;
    }

    private void TurnBoat(OrientationType orientation)
    {
        transform.right = orientation == OrientationType.Left ? 
            Vector3.left : Vector3.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMarker _))
        {
            if (_movementEnabled) return;

            _movementEnabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Harbor harbor))
        {
            _movementEnabled = false;

            TurnBoat(harbor.Orientation);
        }
    }
}
