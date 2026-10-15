using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "HealthDataSo", menuName = "Scriptable Objects/HealthDataSo")]
    public class HealthDataSo : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        public float MaxHealth => _maxHealth;

        [SerializeField] private ParticleEffectType effectType;
        public ParticleEffectType EffectType => effectType;
    }
}


