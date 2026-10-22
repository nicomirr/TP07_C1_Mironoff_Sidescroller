using UnityEngine;
using Game.Core;

namespace Game.Checkpoints
{
    public class CheckpointTracker : MonoBehaviour, ICheckpointSetter, ICheckpointReader
    {        
        private Vector2 _currentCheckpointPosition;
        public Vector2 CurrentCheckpointPosition => _currentCheckpointPosition;

        private bool _firstCheckpointReached;
        public bool FirstCheckpointReached => _firstCheckpointReached;

        
        public void SetCheckpoint(Checkpoint checkpoint)
        {            
            if(!_firstCheckpointReached)
                _firstCheckpointReached = true;

            _currentCheckpointPosition = checkpoint.transform.position;
        }

    }
}


