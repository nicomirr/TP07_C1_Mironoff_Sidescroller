
using Game.Pickables;

namespace Game.Player
{
    public class PlayerHealthEffect : PlayerPickableEffect
    {
        private readonly IHealable _healable;

        public PlayerHealthEffect(IHealable healable)
        {
            _healable = healable;
        }

        public override void Consume(IPickable pickable)
        {
            if (!_healable.TryHeal(pickable.Data.Amount)) return;

            pickable.Consume();
        }
    }
}

