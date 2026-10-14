using UnityEngine;
using Game.Core;
using Game.ParticleEffects;

public class EnemyDeath
{
    private readonly GameObject _enemy;

    public EnemyDeath(GameObject enemy)
    {
        _enemy = enemy;
    }

    public void HandleDeath(float currentHealth, float _)
    {
        if (currentHealth > 0) return;

        CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.GreenSlimeDeath, _enemy.transform.position));
        _enemy.SetActive(false);        
    }    
}
