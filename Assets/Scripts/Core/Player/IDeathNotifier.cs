using UnityEngine;
using System;

namespace Game.Core
{
    public interface IDeathNotifier
    {
        public event Action<bool, float, Vector3> OnDeath;
    }
}

