using UnityEngine;

namespace Game.Core
{
    public interface ICheckpointReader
    {
        public Vector2 CurrentCheckpointPosition {  get; }
        public int CurrentCheckpointValue { get; }
    }

}
