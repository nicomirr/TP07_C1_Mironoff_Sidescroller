using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SceneToLoad", menuName = "Scriptable Objects/SceneToLoad")]
    public class SceneToLoadSo : ScriptableObject
    {
        [SerializeField] private string _sceneToLoadName;
        // Suggestion: Las properties van en PascalCase: SceneToLoadName. Lo mismo pasa con groundCheckDistance en PlayerConfigSo.
        public string sceneToLoadName => _sceneToLoadName;

        [SerializeField] private float _transitionTime;
        public float TransitionTime => _transitionTime;
    }
}


