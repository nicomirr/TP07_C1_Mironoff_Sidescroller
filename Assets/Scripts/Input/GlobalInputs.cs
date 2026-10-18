using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

namespace Game.Inputs
{
    public class GlobalInputs : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseToggleGameObject;

        private GameControls _globalControls;
     
        private InputAction _pauseInput;

        private IPauseToggle _pauseToggle;

        private void Awake()
        {
            _globalControls = new GameControls();

            _pauseInput = _globalControls.Global.Pause;
        }

        private void OnEnable()
        {
            _pauseInput.performed += OnPausePressed;
        }

        private void Start()
        {
            _pauseToggle = _pauseToggleGameObject.GetComponent<IPauseToggle>();

            StartCoroutine(EnablePauseRoutine());
        }

        private void OnDisable()
        {
            _pauseInput.performed -= OnPausePressed;
            _globalControls.Global.Disable();
        }

        private IEnumerator EnablePauseRoutine()
        {
            yield return new WaitForSeconds(0.4f);
            _globalControls.Global.Enable();
        }

        private void OnPausePressed(InputAction.CallbackContext ctx)
        {
            _pauseToggle.TogglePauseState();
        }
    }
}

