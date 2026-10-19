using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Data;
using Game.ParticleEffects;

namespace Game.Management
{
    public class PlayerDeathHandler
    {        
        private readonly PlayerDoll _playerDoll;

        private readonly float _deathTime;
        private readonly float _waterDeathTime;

        private readonly float _restartTime;

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IScreenFader _screenFader;
        private readonly ICheckpointReader _checkpointReader;
        private readonly IPositionReader _positionReader;
        private readonly IReset _playerReset;

        private readonly GameObject _playerObject;

        public PlayerDeathHandler(PlayerDeathHandlerDataSo data, ICoroutineRunner coroutineRunner, IScreenFader screenFader,
            ICheckpointReader checkpointReader, GameObject playerObject, IPositionReader playerInitialPositionReader, IReset playerReset)
        {
            _playerDoll = data.PlayerDollObject.GetComponent<PlayerDoll>();

            _deathTime = data.DeathTime;
            _waterDeathTime = data.WaterDeathTime;

            _restartTime = data.RestartTime;

            _coroutineRunner = coroutineRunner;
            _screenFader = screenFader;
            _checkpointReader = checkpointReader;
            _positionReader = playerInitialPositionReader;
            _playerReset = playerReset;

            _playerObject = playerObject;
        }

        public void HandleDeath(bool isWater, float direction, Vector3 position)
        {
            float delayTime = _deathTime;

            if(isWater)
            {
                CommandBus.Send(new PlayParticleEffectCommand(ParticleEffectType.WaterImpact, position));
                delayTime = _waterDeathTime;
            }
            else
            {
                PlayerDoll doll = GameObject.Instantiate(_playerDoll, position, Quaternion.identity);
                doll.SetAnimation(direction);
            }                

            _coroutineRunner.RunCoroutine(DeathRoutine(delayTime));
        }

        private IEnumerator DeathRoutine(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);

            _screenFader.FadeOut();

            yield return new WaitForSeconds(_restartTime);

            _playerObject.transform.position = _checkpointReader.CurrentCheckpointValue == 0 ?
                _positionReader.Position : _checkpointReader.CurrentCheckpointPosition;

            yield return new WaitForSeconds(_restartTime);

            _screenFader.FadeIn();

            _playerObject.SetActive(true);                

            _playerReset.ResetObject();
        }
    }
}

