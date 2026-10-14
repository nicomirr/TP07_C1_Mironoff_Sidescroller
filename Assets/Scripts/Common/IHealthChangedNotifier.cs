using System;

namespace Game.Common
{
    public interface IHealthChangedNotifier
    {
        public event Action<float, float> OnHealthChanged;
    }

}
