using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerFootstepsDataSo", menuName = "Scriptable Objects/PlayerFootstepsDataSo")]
    public class PlayerFootstepsDataSo : ScriptableObject
    {
        [SerializeField] private List<FootstepDataSo> _footstepsData;
        public List<FootstepDataSo> FootstepsData => _footstepsData;
    }
}

