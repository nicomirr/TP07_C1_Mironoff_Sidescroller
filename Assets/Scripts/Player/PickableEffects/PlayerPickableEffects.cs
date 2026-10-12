using System.Collections.Generic;
using Game.Core;
using Game.Data;
using Game.Pickables;

namespace Game.Player
{
    public class PlayerPickableEffects
    {
        private readonly Dictionary<PickableType, PlayerPickableEffect> _pickableEffects = new();

        public void AddPickable(PickableType pickableType, PlayerPickableEffect pickableEffect)
        {
            _pickableEffects[pickableType] = pickableEffect;
        }

        public void Consume(IPickable pickable)
        {
            _pickableEffects[pickable.Data.PickableType].Consume(pickable);
        }
    }

}


