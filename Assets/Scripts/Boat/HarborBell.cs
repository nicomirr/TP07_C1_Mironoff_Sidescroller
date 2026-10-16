using UnityEngine;
using Game.Marker;
using Game.Data;
using Game.Core;

namespace Game.Boat
{
    public class HarborBell : MonoBehaviour
    {
        [SerializeField] private HarborBellDataSo _data;

        [SerializeField] private GameObject _MovementStopperGameObject;

        [SerializeField] private Transform _boatTransform;
        [SerializeField] private Transform _harborTransform;

        private IMovementStopper _movementStopper;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _movementStopper = _MovementStopperGameObject.GetComponent<IMovementStopper>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ThrowableMarker _))
            {                
                _animator.SetTrigger(_data.BellAnimationTrigger);

                _movementStopper.StopMovement();
                _boatTransform.position = new Vector3(_harborTransform.position.x, _boatTransform.position.y, _boatTransform.position.z);
            }
        }
    }

}

