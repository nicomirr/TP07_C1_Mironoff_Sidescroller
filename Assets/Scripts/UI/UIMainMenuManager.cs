using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Game.UI
{
    public class UIMainMenuManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        [SerializeField] private List<Button> _backButtons;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _creditsButton;
        [SerializeField] private Button _exitButton; 

        [SerializeField] private UIPanel _mainMenuPanel;
        [SerializeField] private UIPanel _settingsPanel;
        [SerializeField] private UIPanel _creditsPanel;

        private UIPanel _previousPanel;
        private UIPanel _currentPanel;

        private bool _wasGamepad;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {           
            _playButton.onClick.AddListener(OnPlayClicked);
            _settingsButton.onClick.AddListener(OnSettingsClicked);
            _creditsButton.onClick.AddListener(OnCreditsClicked);
            _exitButton.onClick.AddListener(OnExitClicked);

            foreach (Button button in _backButtons)
            {
                button.onClick.AddListener(OnBackClicked);
            }
        }

        private void Start()
        {
            _currentPanel = _mainMenuPanel;
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

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _creditsButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();

            foreach (Button button in _backButtons)
            {
                button.onClick.RemoveAllListeners();
            }
        }               

        private void OnPlayClicked()
        {
            _currentPanel.HidePanel();
        }

        private void OnSettingsClicked()
        {
            _previousPanel = _currentPanel;
            _currentPanel = _settingsPanel;

            ChangePanels();
        }

        private void OnCreditsClicked()
        {
            _previousPanel = _currentPanel;
            _currentPanel = _creditsPanel;

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

        private void ChangePanels()
        {
            _previousPanel.HidePanel();
            _currentPanel.DisplayPanel();
            EventSystem.current.SetSelectedGameObject(_currentPanel.GamepadInitialButton.gameObject);
        }
    }
}

