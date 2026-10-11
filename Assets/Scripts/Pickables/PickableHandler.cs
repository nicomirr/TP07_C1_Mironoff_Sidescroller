using System;
using Game.Core;


public class PickableHandler
{
    public event Action<IPickable> OnHealPlayer;

    public void NotifyPickable(IPickable pickable)
    {
        switch (pickable.PickableType)
        {
            case PickableType.HealthPotion:
                OnHealPlayer?.Invoke(pickable);
                break;
        }
    }
}
