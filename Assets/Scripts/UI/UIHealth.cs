using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Game.Data;
using Game.Common;

namespace Game.UI
{
    public class UIHealth : MonoBehaviour
    {
        [SerializeField] private UIHealthDataSo _data;

        [SerializeField] private GameObject _healthChangedNotifierMonobehaviour;

        [SerializeField] private Image _fillImage;

        private IHealthChangedNotifier _healthChangeNotifier;

        private CanvasGroup _canvasGroup;

        private Coroutine _displayHealthRoutine;


        private void Awake()
        {
            _healthChangeNotifier = _healthChangedNotifierMonobehaviour.GetComponent<IHealthChangedNotifier>();

            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _healthChangeNotifier.OnHealthChanged += UpdateHealth;
        }

        private void Start()
        {
            _canvasGroup.alpha = 0;
            _fillImage.fillAmount = 1;
        }

        private void OnDisable()
        {
            _healthChangeNotifier.OnHealthChanged -= UpdateHealth;
        }

        public void UpdateHealth(float currentHealth, float maxHealth)
        {
            _fillImage.fillAmount = currentHealth / maxHealth;

            if (_displayHealthRoutine != null)
            {
                StopCoroutine(_displayHealthRoutine);
                _displayHealthRoutine = null;
            }

            _displayHealthRoutine = StartCoroutine(DisplayHealthUI());
        }

        private IEnumerator DisplayHealthUI()
        {
            _canvasGroup.alpha = 1;

            yield return new WaitForSeconds(_data.DisplayTime);

            _canvasGroup.alpha = 0;
        }
    }

}

