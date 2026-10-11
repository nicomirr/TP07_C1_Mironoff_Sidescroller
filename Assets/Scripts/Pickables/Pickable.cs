using UnityEngine;
using Game.Data;
using Game.Core;

public class Pickable : MonoBehaviour, IPickable
{
    [SerializeField] private PickableDataSo _pickableData;

    public float Amount => _pickableData.Amount;

    public PickableType PickableType => _pickableData.PickableType;

    public void Consume()
    {
        this.gameObject.SetActive(false);
    }
}
