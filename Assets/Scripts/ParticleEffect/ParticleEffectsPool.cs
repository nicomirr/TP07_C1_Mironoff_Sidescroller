using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.ParticleEffects
{
    public class ParticleEffectsPool 
    {
        private readonly ParticleEffectFactory _particleEffectFactory;

        private readonly Dictionary<ParticleEffectType, List<ParticleSystem>> _particleEffects = new();
       
        public ParticleEffectsPool(ParticleEffectFactory particleEffectFactory)
        {
            _particleEffectFactory = particleEffectFactory;            
        }

        public ParticleSystem RequestParticleSystem(ParticleEffectType type)
        {
            if (!_particleEffects.ContainsKey(type))
                _particleEffects.Add(type, _particleEffectFactory.CreatePool(type));

            List<ParticleSystem> currentParticleSystems = _particleEffects[type];

            foreach (ParticleSystem particleSystem in currentParticleSystems)
            {
                if (!particleSystem.isPlaying)
                {
                    particleSystem.gameObject.SetActive(false);
                    return particleSystem;
                }
            }

            Debug.LogError("Error. El pool de particulas debe tener siempre un objeto disponible.");

            return null;
        }        
    }

}


