using System;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Player
{
    public class PlayerCollectibles
    {
        public event Action<CollectibleType, int> OnCollectibleChanged;

        private readonly Dictionary<CollectibleType, int> _collectibles = new();

        public PlayerCollectibles()
        {
            foreach (CollectibleType type in Enum.GetValues(typeof(CollectibleType)))
            {
                _collectibles.Add(type, 0);
            }
        }

        public PickableDataSo Data => throw new NotImplementedException();

        public void AddCollectible(CollectibleType type)
        {
            _collectibles[type]++;

            OnCollectibleChanged?.Invoke(type, _collectibles[type]);
        }        
    }
}


