using UnityEngine;
using Game.Data;
using Game.SceneTransitions;
using Game.Marker;

namespace Game.Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private SceneToLoadSo _sceneToLoad;

        [SerializeField] private GameObject _sceneChangerGameObject;

        private ISceneChanger _sceneChanger;

        private void Awake()
        {
            _sceneChanger = _sceneChangerGameObject.GetComponent<ISceneChanger>();

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerMarker playerMarker))
            {
                _sceneChanger.ChangeScene(_sceneToLoad);    
            }
        }
    }

}
