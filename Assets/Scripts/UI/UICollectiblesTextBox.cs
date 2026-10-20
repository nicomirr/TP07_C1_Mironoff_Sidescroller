using UnityEngine;
using TMPro;
using Game.Core;

namespace Game.UI
{
    [System.Serializable]
    public struct UICollectiblesTextBox
    {
        [SerializeField] private CollectibleType _collectibleType;
        public CollectibleType CollectibleType => _collectibleType;

        [SerializeField] private TMP_Text _textBox;
        public TMP_Text TextBox => _textBox;
    }

}

