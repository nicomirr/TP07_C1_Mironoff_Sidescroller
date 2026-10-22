using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Data;
using Game.Marker;
using TMPro;

namespace Game.Quests
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private DialogueDataSo _data;

        [SerializeField] private TMP_Text _textBox;

        private AudioSource _audioSource;

        private List<string> _currentDialogue;

        private Coroutine _dialogueRoutine;

        private bool _dialogueDisplaying;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _currentDialogue = _data.AvailableQuestText;
        }

        private IEnumerator DialogueRoutine()
        {
            foreach (string dialogue in _currentDialogue)
            {
                for (int i = 0; i < dialogue.Length; i++)
                {
                    _textBox.text += dialogue[i];

                    if (!_audioSource.isPlaying)
                        _audioSource.Play();

                    yield return new WaitForSeconds(_data.LetterDelayTime);
                }

                yield return new WaitForSeconds(1f);

                _textBox.text = string.Empty;
            }

            _dialogueRoutine = null;
            _dialogueDisplaying = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out PlayerMarker _)) return;

            if (_dialogueDisplaying) return;

            _dialogueRoutine = StartCoroutine(DialogueRoutine());

            _dialogueDisplaying = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out PlayerMarker _)) return;

            if (_dialogueRoutine == null) return;

            StopCoroutine(_dialogueRoutine);
            _dialogueRoutine = null;

            if (_audioSource.isPlaying)
                _audioSource.Stop();

            _textBox.text = string.Empty;
            _dialogueDisplaying = false;
        }
    }

}

