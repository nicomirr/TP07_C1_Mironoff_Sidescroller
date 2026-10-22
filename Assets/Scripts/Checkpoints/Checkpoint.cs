using UnityEngine;
using System.Collections;
using Game.Data;
using Game.Marker;

namespace Game.Checkpoints
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private GameObject _checkpointSetterObject;

        [SerializeField] private CheckpointDataSo _data;
        [SerializeField] private CanvasGroup _checkpointTextCanvasGroup;

        private static Checkpoint _instance;

        private AudioSource _audioSource;

        private Animator _animator;

        private ICheckpointSetter _checkpointSetter;

        private bool _checkpointUsed;


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
            if (!collision.TryGetComponent(out PlayerMarker _)) return;

            if (_checkpointUsed) return;

            _animator.SetBool(_data.CheckpointUsedAnimationHash, true);
            _audioSource.Play();

            _checkpointUsed = true;

            _checkpointSetter.SetCheckpoint(this);

            StartCoroutine(DisplayCheckpointRoutine());

            if(_instance == null)
            {
                _instance = this;
                return;
            }

            _instance.ReenableCheckpoint();
            _instance = this;
        }

        private void ReenableCheckpoint()
        {
            _animator.SetBool(_data.CheckpointUsedAnimationHash, false);
            _checkpointUsed = false;
        }

    }
}


