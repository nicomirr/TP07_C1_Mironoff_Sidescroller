using Game.Data;
using Game.SceneTransitions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIMenuManager : MonoBehaviour
    {
        [SerializeField] protected SceneToLoadSo _sceneToLoad;

        [SerializeField] private GameObject _sceneChangerGameObject;

        [SerializeField] private List<Button> _backButtons;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton; 

        [SerializeField] protected UIPanel _mainPanel;
        [SerializeField] private UIPanel _settingsPanel;
        
        private PlayerInput _playerInput;

        protected ISceneChanger _sceneChanger;

        protected UIPanel _previousPanel;
        protected UIPanel _currentPanel;

        private bool _wasGamepad;

        protected virtual void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        protected virtual void OnEnable()
        {           
            _playButton.onClick.AddListener(OnPlayClicked);
            _settingsButton.onClick.AddListener(OnSettingsClicked);
            _exitButton.onClick.AddListener(OnExitClicked);

            foreach (Button button in _backButtons)
            {
                button.onClick.AddListener(OnBackClicked);
            }
        }

        protected virtual void Start()
        {
            _sceneChanger = _sceneChangerGameObject.GetComponent<ISceneChanger>();

            _currentPanel = _mainPanel;
            _currentPanel.DisplayPanel();

            EventSystem.current.SetSelectedGameObject(_currentPanel.GamepadInitialButton.gameObject);
        }

        private void Update()
        {
            bool isGamepad = _playerInput.currentControlScheme == "Gamepad";

            if (isGamepad != _wasGamepad)            
                EventSystem.current.SetSelectedGameObject(isGamepad ? _currentPanel.GamepadInitialButton.gameObject : null);            

            _wasGamepad = isGamepad;
        }

        protected virtual void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();

            foreach (Button button in _backButtons)
            {
                button.onClick.RemoveAllListeners();
            }
        }               

        protected virtual void OnPlayClicked()
        {
            _currentPanel.HidePanel();
            _sceneChanger.ChangeScene(_sceneToLoad);
        }

        private void OnSettingsClicked()
        {
            _previousPanel = _currentPanel;
            _currentPanel = _settingsPanel;

            ChangePanels();
        }        

        private void OnExitClicked()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        private void OnBackClicked()
        {
            UIPanel panel = _currentPanel;

            _currentPanel = _previousPanel;
            _previousPanel = panel;

            ChangePanels();            
        }

        protected void ChangePanels()
        {
            _previousPanel.HidePanel();
            _currentPanel.DisplayPanel();
            EventSystem.current.SetSelectedGameObject(_currentPanel.GamepadInitialButton.gameObject);
        }
    }
}

