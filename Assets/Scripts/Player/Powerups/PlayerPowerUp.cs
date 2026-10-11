using UnityEngine;
using Game.Data;
using Game.Core;

namespace Game.Player
{
    public abstract class PlayerPowerUp
    {
        protected PowDataSo _data;

        protected ICoroutineRunner _coroutineRunner;
        protected IPlayerStateChanger _playerStateChanger;

        protected SpriteRenderer _spriteRenderer;
        protected PlayerSpriteFlicker _spriteFlicker;

        public abstract bool TryEnablePowerUp();       
    }

}
