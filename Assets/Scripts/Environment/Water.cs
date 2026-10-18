using UnityEngine;
using Game.Core;
using Game.Marker;
using Game.ParticleEffects;
using Game.Data;

namespace Game.Environment
{
    public class Water : MonoBehaviour
    {
        [SerializeField] private WaterDataSo _data;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out EnemyMarker _) || collision.gameObject.TryGetComponent(out ThrowableMarker _))
            {
                collision.gameObject.SetActive(false);
                CommandBus.Send(new PlayParticleEffectCommand(_data.EffectType, collision.transform.position));
            }
        }
    }
}
