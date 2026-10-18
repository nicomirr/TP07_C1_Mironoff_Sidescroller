using UnityEngine;
using System.Collections.Generic;
using Game.UI;
using Game.Core;
using System;

namespace Game.Pause
{
    public class PauseManager : MonoBehaviour, IPauseToggle, IPauseNotifier
    {
        [SerializeField] private List<UIPanel> _otherPanels;
        [SerializeField] private UIPanel _pausePanel;

        private bool _gamePaused;

        public event Action OnGamePaused;
        public event Action OnGameUnpaused;

        public void TogglePauseState()
        {           
            _gamePaused = !_gamePaused;

            if (_gamePaused)
            {
                OnGamePaused?.Invoke();
                _pausePanel.DisplayPanel();
            }
            else
            {
                OnGameUnpaused?.Invoke();
                _pausePanel.HidePanel();
                
                foreach(UIPanel panel in _otherPanels)
                    panel.HidePanel();
            }

                //CursorEvents.RaiseChangeCursorVisibilityRequest(_gamePaused);

            Time.timeScale = _gamePaused ? 0f : 1f;            
        }
    }
}

