using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "GameManagerDataSo", menuName = "Scriptable Objects/GameManagerDataSo")]
    public class GameManagerDataSo : ScriptableObject
    {
        [SerializeField] private GameObject _playerDollObject;
        public GameObject PlayerDollObject => _playerDollObject;
    }
}
