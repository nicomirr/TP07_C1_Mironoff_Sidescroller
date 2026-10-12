using Game.Pickables;

namespace Game.Player
{
    public abstract class PlayerPickableEffect
    {
        public abstract void Consume(IPickable pickable);
    }

}

