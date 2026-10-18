using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "WaterDataSo", menuName = "Scriptable Objects/WaterDataSo")]
    public class WaterDataSo : ScriptableObject
    {
        [SerializeField] private ParticleEffectType _effectType;
        public ParticleEffectType EffectType => _effectType;
    }

}

