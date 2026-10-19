using UnityEngine;
using System.Collections;
using Game.Data;

namespace Game.Checkpoints
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private GameObject _checkpointSetterObject;

        [SerializeField] private int _checkpointNumber;

        [SerializeField] private CheckpointDataSo _data;
        [SerializeField] private CanvasGroup _checkpointTextCanvasGroup;        

        private AudioSource _audioSource;

        private Animator _animator;

        private ICheckpointSetter _checkpointSetter;

        private bool _checkpointUsed;

        public int CheckpointNumber => _checkpointNumber;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponentInChildren<Animator>();

            _checkpointSetter = _checkpointSetterObject.GetComponent<ICheckpointSetter>();
        }

        private IEnumerator DisplayCheckpointRoutine()
        {
            for(int i = 0; i < _data.DisplayTimes; i++)
            {
                _checkpointTextCanvasGroup.alpha = 1;
                yield return new WaitForSeconds(_data.DisplayDelay);

                _checkpointTextCanvasGroup.alpha = 0;
                yield return new WaitForSeconds(_data.DisplayDelay);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_checkpointUsed) return;

            _animator.SetTrigger(_data.CheckpointUsedAnimationHash);
            _audioSource.Play();

            _checkpointUsed = true;

            _checkpointSetter.SetCheckpoint(this);

            StartCoroutine(DisplayCheckpointRoutine());
        }

        public void DisableCheckpoint()
        {
            if(_checkpointUsed) return;

            _animator.SetTrigger(_data.CheckpointUsedAnimationHash);
            _checkpointUsed = true;
        }
    }
}


