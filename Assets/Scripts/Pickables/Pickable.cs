using UnityEngine;
using Game.Data;
using Game.Marker;

namespace Game.Pickables
{
    public class Pickable : MonoBehaviour, IPickable
    {
        [SerializeField] private PickableDataSo _pickableData;
        public PickableDataSo Data => _pickableData;

        public void Consume()
        {
            this.gameObject.SetActive(false);
        }
    }

}

