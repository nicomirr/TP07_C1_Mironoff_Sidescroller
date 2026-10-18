using UnityEngine;
using Game.Core;

namespace Game.ParticleEffects
{
    public class ParticleEffectsPlayer
    {
        private readonly ParticleEffectsPool _particleEffectsPool;

        public ParticleEffectsPlayer(ParticleEffectsPool particleEffectsPool)
        {
            _particleEffectsPool = particleEffectsPool;
        }

        public void PlayEffect(ParticleEffectType type, Vector2 position)
        {
            ParticleSystem particleSystem = _particleEffectsPool.RequestParticleSystem(type);            

            if (particleSystem == null)
            {
                Debug.LogError("Error. El pool de particulas retorno null. Revisar problema en pool.");

                return;
            }

            particleSystem.transform.position = position;
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();
        }

    }        
}


