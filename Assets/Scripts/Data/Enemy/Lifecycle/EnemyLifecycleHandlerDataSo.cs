using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyLifecycleHandlerData", menuName = "Scriptable Objects/EnemyLifecycleHandlerData")]
    public class EnemyLifecycleHandlerDataSo : ScriptableObject
    {
        [SerializeField] private LootDropperDataSo _lootDropperData;
        public LootDropperDataSo LootDropperData => _lootDropperData;

        [SerializeField] private float _respawnTime;
        public float RespawnTime => _respawnTime;
    }

}

