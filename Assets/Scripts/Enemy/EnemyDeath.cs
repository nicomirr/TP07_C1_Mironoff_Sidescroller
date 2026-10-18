using UnityEngine;
using Game.Core;
using Game.Data;
using Game.ParticleEffects;

public class EnemyDeath
{
    private readonly GameObject _enemy;
    private readonly ParticleEffectType _effectType;

    public EnemyDeath(HealthDataSo data, GameObject enemy)
    {
        _effectType = data.EffectType;
        _enemy = enemy;
    }

    public void HandleDeath(float currentHealth, float _)
    {
        if (currentHealth > 0) return;

        CommandBus.Send(new PlayParticleEffectCommand(_effectType, _enemy.transform.position));

        _enemy.SetActive(false);        
    }    
}
