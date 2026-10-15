using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "HarborDataSo", menuName = "Scriptable Objects/HarborDataSo")]
    public class HarborDataSo : ScriptableObject
    {
        [SerializeField] private OrientationType _orientation;
        public OrientationType Orientation => _orientation;
    }

}

