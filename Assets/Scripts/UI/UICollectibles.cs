using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Game.UI;
using Game.Core;
using Game.Player;

public class UICollectibles : MonoBehaviour
{
    [SerializeField] private GameObject _collectiblesProviderGameObject;

    [SerializeField] private List<UICollectiblesTextBox> _textBoxes;

    private readonly Dictionary<CollectibleType, TMP_Text> _textBoxesDictionary = new();

    private ICollectiblesProvider _collectiblesProvider;

    private void Awake()
    {
        foreach(UICollectiblesTextBox textBox in _textBoxes)
        {
            _textBoxesDictionary.Add(textBox.CollectibleType, textBox.TextBox);
        }

        _collectiblesProvider = _collectiblesProviderGameObject.GetComponent<ICollectiblesProvider>();
    }

    private void Start()
    {
        _collectiblesProvider.Collectibles.OnCollectibleChanged += UpdateUI;
    }

    private void OnDestroy()
    {
        _collectiblesProvider.Collectibles.OnCollectibleChanged -= UpdateUI;
    }

    private void UpdateUI(CollectibleType type, int value)
    {
        _textBoxesDictionary[type].text = "x " + value.ToString("D2");
    }
}
