using UnityEngine;
using System.Collections;
using Game.Data;
using Game.Core;

namespace Game.Player
{
    public class PlayerInvincibilityPowerUp : PlayerPowerUp
    {
        private InvincibilityPowDataSo _data;

        protected SpriteRenderer _spriteRenderer;
        protected PlayerSpriteFlicker _spriteFlicker;

        public PlayerInvincibilityPowerUp(ICoroutineRunner coroutineRunner, IPlayerStateChanger stateChanger,
            PlayerSpriteFlicker spriteFlicker, SpriteRenderer spriteRenderer)
        {
            _coroutineRunner = coroutineRunner;
            _playerStateChanger = stateChanger;

            _spriteFlicker = spriteFlicker;
            _spriteRenderer = spriteRenderer;
        }

        public override bool EnablePowerUp(PowerUpDataSo data)
        {
            if (!_playerStateChanger.TryChangeState(PlayerState.Invincible)) return false;

            _data = data as InvincibilityPowDataSo;

            _coroutineRunner.RunCoroutine(InvincibilityRoutine());

            return true;
        }

        public IEnumerator InvincibilityRoutine()
        {
            _spriteRenderer.color = _data.FlickerColor;

            yield return new WaitForSeconds(_data.Time - _data.WarningTime);

            yield return _spriteFlicker.FlickerRoutine(_data.WarningTime, _data.TotalBlinks, _data.FlickerColor);

            if (!_playerStateChanger.TryChangeState(PlayerState.Normal))
                Debug.LogError("ERROR. Debería poder salir a normal siempre al terminar invencibilidad");
        }
    }
}

