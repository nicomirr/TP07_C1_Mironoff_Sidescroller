using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "CollectibleDataSo", menuName = "Scriptable Objects/CollectibleDataSo")]
    public class CollectibleDataSo : ScriptableObject
    {
        [SerializeField] private CollectibleType _collectibleType;
        public CollectibleType CollectibleType => _collectibleType;
    }

}

