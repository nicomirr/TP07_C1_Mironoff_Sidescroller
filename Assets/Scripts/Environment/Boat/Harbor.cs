using UnityEngine;
using Game.Data;
using Game.Core;

public class Harbor : MonoBehaviour
{
    [SerializeField] private HarborDataSo _data;

    public OrientationType Orientation => _data.Orientation;
}
