using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIPauseManager : UIMenuManager
    {
        [SerializeField] private GameObject _pauseToggleGameObject;
        [SerializeField] private Button _mainMenuButton;

        private IPauseToggle _pauseToggle;

        protected override void OnEnable()
        {
            base.OnEnable();

            _mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _mainMenuButton.onClick.RemoveAllListeners();
        }

        protected override void Start()
        {
            base.Start();

            _pauseToggle = _pauseToggleGameObject.GetComponent<IPauseToggle>();
            
            _currentPanel.HidePanel();

        }

        protected override void OnPlayClicked()
        {
            _pauseToggle.TogglePauseState();
            _currentPanel.HidePanel();
        }

        private void OnMainMenuClicked()
        {
            _currentPanel.HidePanel();

            _sceneChanger.ChangeScene(_sceneToLoad);
        }
    }

}

