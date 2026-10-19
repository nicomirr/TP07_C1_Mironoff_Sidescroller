using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "GameManagerDataSo", menuName = "Scriptable Objects/GameManagerDataSo")]
    public class GameManagerDataSo : ScriptableObject
    {
        [SerializeField] private PlayerDeathHandlerDataSo _deathHandlerData;
        public PlayerDeathHandlerDataSo DeathHandlerData => _deathHandlerData;
    }
}
