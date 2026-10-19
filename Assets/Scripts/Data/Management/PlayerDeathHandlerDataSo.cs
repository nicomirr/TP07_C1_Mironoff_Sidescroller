using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerDeathHandlerDataSo", menuName = "Scriptable Objects/PlayerDeathHandlerDataSo")]
    public class PlayerDeathHandlerDataSo : ScriptableObject
    {
        [SerializeField] private GameObject _playerDollObject;
        public GameObject PlayerDollObject => _playerDollObject;

        [SerializeField] private float _deathTime;
        public float DeathTime => _deathTime;

        [SerializeField] private float _waterDeathTime;
        public float WaterDeathTime => _waterDeathTime;

        [SerializeField] private float _restartTime;
        public float RestartTime => _restartTime;   
    }
}

