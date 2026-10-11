using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PickableDataSo", menuName = "Scriptable Objects/PickableDataSo")]
    public class PickableDataSo : ScriptableObject
    {
        [SerializeField] private float _amount;
        public float Amount => _amount;

        [SerializeField] private PickableType _pickableType;
        public PickableType PickableType => _pickableType;
    }

}

