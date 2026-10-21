using UnityEngine;
using Game.Core;
using Game.ParticleEffects;

public class FishDeactivator : MonoBehaviour
{
    [SerializeField] private LayerMask _fishLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_fishLayer.value & (1 << collision.gameObject.layer)) == 0)  return;
        
        CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.WaterImpact, collision.transform.position));
        collision.gameObject.SetActive(false);
        
    }
}
