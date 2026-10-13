using UnityEngine;
using Game.Core;
using Game.Data;

namespace Game.ParticleEffects
{    
    public class ParticleEffectsController : MonoBehaviour
    {
        [SerializeField] private ParticleEffectFactoryDataSo _data;
                
        private ParticleEffectsPlayer _particleEffectsPlayer;

        private void Awake()
        {
            ParticleEffectsPool particleEffectsPool = new ParticleEffectsPool(new ParticleEffectFactory(_data, this.transform)); 
            _particleEffectsPlayer = new ParticleEffectsPlayer(particleEffectsPool);
        }

        private void OnEnable()
        {
            CommandBus.Register<PlayParticleEffectCommand>(HandlePlayParticleEffect);
        }

        private void OnDisable()
        {
            CommandBus.Unregister<PlayParticleEffectCommand>(HandlePlayParticleEffect);
        }

        private void HandlePlayParticleEffect(PlayParticleEffectCommand command)
        {
            _particleEffectsPlayer.PlayEffect(command.Type, command.Position);
        }
    }

}
