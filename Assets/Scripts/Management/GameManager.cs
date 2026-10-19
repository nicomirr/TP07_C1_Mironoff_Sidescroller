using UnityEngine;
using Game.Core;
using Game.Data;

namespace Game.Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameManagerDataSo _data;

        [SerializeField] private GameObject _playerDeathNotifierObject;

        private PlayerDeathHandler _playerDeathHandler;

        private IDeathNotifier _playerDeathNotifier;

        private void Awake()
        {
            _playerDeathNotifier = _playerDeathNotifierObject.GetComponent<IDeathNotifier>();

            _playerDeathHandler = new PlayerDeathHandler(_data);
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

    }

}
