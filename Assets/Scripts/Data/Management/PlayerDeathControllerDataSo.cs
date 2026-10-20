using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerDeathControllerDataSo", menuName = "Scriptable Objects/PlayerDeathControllerDataSo")]
    public class PlayerDeathControllerDataSo : ScriptableObject
    {
        [SerializeField] private PlayerDeathHandlerDataSo _deathHandlerData;
        public PlayerDeathHandlerDataSo DeathHandlerData => _deathHandlerData;
    }
}
