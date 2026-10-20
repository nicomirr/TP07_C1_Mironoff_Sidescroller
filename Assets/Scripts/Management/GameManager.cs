using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Data;

namespace Game.Management
{
    public class GameManager : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameManagerDataSo _data;

        [SerializeField] private GameObject _playerObject;

        [SerializeField] private GameObject _screenFaderObject;

        [SerializeField] private GameObject _checkpointReaderObject;

        [SerializeField] private GameObject _pauseToggleableObject;

        private PlayerDeathHandler _playerDeathHandler;

        private IDeathNotifier _playerDeathNotifier;

        private void Awake()
        {
            _playerDeathNotifier = _playerObject.GetComponent<IDeathNotifier>();
           
            IScreenFader screenFader = _screenFaderObject.GetComponent<IScreenFader>();
           
            ICheckpointReader checkpointReader = _checkpointReaderObject.GetComponent<ICheckpointReader>();

            IPositionReader playerInitialPositionReader = _playerObject.GetComponent<IPositionReader>();

            IReset playerReset = _playerObject.GetComponent<IReset>();

            IToggleable toggleable = _pauseToggleableObject.GetComponent<IToggleable>();

            _playerDeathHandler = new PlayerDeathHandler(_data.DeathHandlerData, this, screenFader, checkpointReader, _playerObject, 
                playerInitialPositionReader, playerReset, toggleable);
        }

        private void OnEnable()
        {
            _playerDeathNotifier.OnDeath += HandlePlayerDeath;
        }

        private void OnDisable()
        {
            _playerDeathNotifier.OnDeath -= HandlePlayerDeath;
        }

        private void HandlePlayerDeath(bool isWater, float direction, Vector3 position)
        {
            _playerDeathHandler.HandleDeath(isWater, direction, position);
        }

        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }
    }

}
