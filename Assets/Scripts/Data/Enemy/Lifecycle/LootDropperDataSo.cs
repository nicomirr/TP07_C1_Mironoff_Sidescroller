using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "LootDroperDataSo", menuName = "Scriptable Objects/LootDroperDataSo")]
    public class LootDropperDataSo : ScriptableObject
    {
        [SerializeField] private GameObject _droppablePrefab;
        public GameObject DroppablePrefab => _droppablePrefab;

        [SerializeField] private float _dropChance;
        public float DropChance => _dropChance;
    }

}

