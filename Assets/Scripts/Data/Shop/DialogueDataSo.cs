using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "DialogueDataSo", menuName = "Scriptable Objects/DialogueDataSo")]
    public class DialogueDataSo : ScriptableObject
    {
        [TextArea][SerializeField] private List<string> _availableQuestText;
        public List<string> AvailableQuestText => _availableQuestText;

        [TextArea][SerializeField] private List<string> _finalizedQuestText;
        public List<string> FinalizedQuestText => _finalizedQuestText;

        [SerializeField] private float _letterDelayTime;
        public float LetterDelayTime => _letterDelayTime;
    }
}

