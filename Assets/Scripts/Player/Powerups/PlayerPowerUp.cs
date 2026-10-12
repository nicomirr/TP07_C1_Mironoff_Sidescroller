using UnityEngine;
using Game.Data;
using Game.Core;

namespace Game.Player
{
    public abstract class PlayerPowerUp
    {        
        protected ICoroutineRunner _coroutineRunner;
        protected IPlayerStateChanger _playerStateChanger;
        public abstract bool EnablePowerUp(PowerUpDataSo data);       
    }

}
