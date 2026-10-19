using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Marker;
using Game.ParticleEffects;
using System.Collections;

namespace Game.Management
{
    public class PlayerDoll : MonoBehaviour
    {
        [SerializeField] private PlayerDollDataSo _data;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            StartCoroutine(DestroyRoutine());
        }

        public void SetAnimation(float direction)
        {
            if(direction > 0)
            {
                _animator.SetTrigger(_data.RightDeathAnimationHash);
                return;
            }

            _animator.SetTrigger(_data.LeftDeathAnimationHash);
        }

        private IEnumerator DestroyRoutine()
        {
            yield return new WaitForSeconds(_data.DestroyTime);

            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out WaterMarker _))
            {
                CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.WaterImpact, this.transform.position));
                this.gameObject.SetActive(false);
            }
        }
    }
}
