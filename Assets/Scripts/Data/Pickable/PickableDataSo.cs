using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PickableDataSo", menuName = "Scriptable Objects/PickableDataSo")]
    public class PickableDataSo : ScriptableObject
    {       
        [SerializeField] private PickableType _pickableType;
        public PickableType PickableType => _pickableType;
                
        [SerializeField] private int _amount;
        public int Amount => _amount;

        [SerializeField] private float _despawnTime;
        public float DespawnTime => _despawnTime;
    }

}

