using UnityEngine;
using Game.Core;

namespace Game.Checkpoints
{
    public class CheckpointTracker : MonoBehaviour, ICheckpointSetter, ICheckpointReader
    {        
        private Vector2 _currentCheckpointPosition;
        public Vector2 CurrentCheckpointPosition => _currentCheckpointPosition;

        private int _currentCheckpointValue;
        public int CurrentCheckpointValue => _currentCheckpointValue;

        private void Start()
        {
            _currentCheckpointValue = 0;
        }

        public void SetCheckpoint(Checkpoint checkpoint)
        {
            if (_currentCheckpointValue > checkpoint.CheckpointNumber) return;

            _currentCheckpointValue = checkpoint.CheckpointNumber;
            _currentCheckpointPosition = checkpoint.transform.position;
        }

    }
}


