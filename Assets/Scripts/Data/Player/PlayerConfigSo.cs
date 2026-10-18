using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerConfigSo", menuName = "Scriptable Objects/PlayerConfigSo")]
    public class PlayerConfigSo : ScriptableObject
    {
        [SerializeField] private StateMachineTransitionsConfigSo _fsmTransitionsData;
        public StateMachineTransitionsConfigSo FsmTransitionsData => _fsmTransitionsData;

        [SerializeField] private AnimationConfigSo _animationsConfig;
        public AnimationConfigSo AnimationsConfig => _animationsConfig;

        [SerializeField] private ThrowableFactoryDataSo _throwablesFactoryData;
        public ThrowableFactoryDataSo ThrowablesFactoryData => _throwablesFactoryData;

        [SerializeField] private ThrowableType _initialThrowableType;
        public ThrowableType InitialThrowableType => _initialThrowableType;

        [SerializeField] private float _throwCooldown;
        public float ThrowCooldown => _throwCooldown;

        [SerializeField] private AudioConfigSo _audioConfigData;
        public AudioConfigSo AudioConfigData => _audioConfigData;

        [SerializeField] private DamageFlickerDataSo _damageFlickerData;
        public DamageFlickerDataSo DamageFlickerData => _damageFlickerData;

        [SerializeField] private HealthDataSo _healthData;
        public HealthDataSo HealthData => _healthData;

        [SerializeField] private KnockbackDataSo _knockbackData;
        public KnockbackDataSo KnockbackData => _knockbackData;

        [SerializeField] private GravityDataSo _gravityData;
        public GravityDataSo GravityData => _gravityData;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        [SerializeField] private JumpDataSo _jumpData;
        public JumpDataSo JumpData => _jumpData;

        [SerializeField] private float _groundCheckDistance;
        public float groundCheckDistance => _groundCheckDistance;

        [SerializeField] private LayerMask _groundLayer;
        public LayerMask GroundLayer => _groundLayer;

        [SerializeField] private Vector2 _groundCheckSize;
        public Vector2 GroundCheckSize => _groundCheckSize;

        [SerializeField] private PlayerFootstepsDataSo _playerFootstepsData;
        public PlayerFootstepsDataSo PlayerFootstepsData => _playerFootstepsData;

    }

}

