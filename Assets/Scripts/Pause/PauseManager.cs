using UnityEngine;
using System.Collections.Generic;
using Game.UI;

namespace Game.Pause
{
    public class PauseManager : MonoBehaviour, IPauseToggle
    {
        [SerializeField] private List<UIPanel> _otherPanels;
        [SerializeField] private UIPanel _pausePanel;

        private bool _gamePaused;
                         
        public void TogglePauseState()
        {           
            _gamePaused = !_gamePaused;

            if (_gamePaused)
                _pausePanel.DisplayPanel();
            else
            {
                _pausePanel.HidePanel();
                
                foreach(UIPanel panel in _otherPanels)
                    panel.HidePanel();
            }

                //CursorEvents.RaiseChangeCursorVisibilityRequest(_gamePaused);

            Time.timeScale = _gamePaused ? 0f : 1f;            
        }
    }
}

