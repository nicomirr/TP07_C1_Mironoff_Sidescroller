using UnityEngine;
using System.Collections;
using Game.AnimationSystem;
using Game.Audio;
using Game.Core;
using Game.Data;
using Game.Marker;
using Game.Throwables;
using Game.Common;
using Game.UI;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private PlayerDoll _doll;

        [SerializeField] private PlayerConfigSo _data;

        [SerializeField] private UIHealth _UIHealth;

        [SerializeField] private Transform _throwablesParent;

        private Rigidbody2D _rb;

        private PlayerAnimationEvents _playerAnimationEvents; 

        private PlayerInputs _playerInputs;
        private PlayerStateMachine _playerFsm;
        private PlayerAnimations _playerAnimations;
        private PlayerFacing _playerFacing;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerGroundCheck _playerGroundCheck;
        private PlayerGravity _playerGravity;
        private PlayerThrow _playerThrow;
        private Health _playerHealth;
        private PickableHandler _pickableHandler;
        private PlayerCollisionHandler _playerCollisionHandler;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            _playerFsm = new PlayerStateMachine(_data);

            _playerAnimationEvents = GetComponentInChildren<PlayerAnimationEvents>();

            _playerInputs = new PlayerInputs();

            AnimationLibrary animationLibrary = new AnimationLibrary(_data.AnimationsConfig, this.gameObject);
            AnimationHandler animationHandler = new AnimationHandler(GetComponentInChildren<Animator>(), animationLibrary);

            _playerAnimations = new PlayerAnimations(animationHandler);

            _playerFacing = new PlayerFacing(this.transform);

            _playerMovement = new PlayerMovement(_rb, _data);

            AudioPlayer audioPlayer = new AudioPlayer(_data.AudioConfigData, GetComponentInChildren<AudioSource>());
                        
            _playerJump = new PlayerJump(_rb, _data);

            Transform groundCheck = GetComponentInChildren<GroundCheckMarker>().transform;
            _playerGroundCheck = new PlayerGroundCheck(groundCheck, _data);

            _playerGravity = new PlayerGravity(_rb, _data);

            ThrowableFactory throwableFactory = new ThrowableFactory(_data.ThrowablesFactoryData, _throwablesParent);

            ThrowablePool throwablePool = new ThrowablePool(throwableFactory);

            _playerThrow = new PlayerThrow(throwablePool, GetComponentInChildren<ThrowableOriginMarker>().transform, _data);

            _playerHealth = new Health(_data.HealthData);

            GameObject playerImageObject = GetComponentInChildren<PlayerImageMarker>().gameObject;
            PlayerSpriteFlicker spriteFlicker = new PlayerSpriteFlicker(playerImageObject.GetComponent<SpriteRenderer>());

            PlayerKnockback knockback = new PlayerKnockback(_data, _rb);

            PlayerDamageHandler damageHandler = new PlayerDamageHandler(_data, _playerHealth, knockback, spriteFlicker, this, _playerFsm, gameObject);
            _pickableHandler = new PickableHandler();
            
            _playerCollisionHandler = new PlayerCollisionHandler(_playerFsm, damageHandler, _pickableHandler);
        }

        private void OnEnable()
        {
            _pickableHandler.OnHealPlayer += _playerHealth.Heal;

            _playerAnimationEvents.OnThrowFinished += HandleThrowFinished;

            _playerGroundCheck.OnJustLanded += HandleLand;

            _playerHealth.OnHealthChanged += _UIHealth.UpdateHealth;
        }

        private void FixedUpdate()
        {            
            HandleMovement();     
        }

        private void Update()
        {
            HandlePlayerDirection();

            _playerJump.UpdateCoyoteTime(_playerGroundCheck.IsGrounded);
            HandleJump(); 
            
            _playerThrow.UpdateThrowTimer();
            HandleThrow();

            HandleThrowMovement();

            HandleDeath();
        }

        private void OnDisable()
        {
            _pickableHandler.OnHealPlayer -= _playerHealth.Heal;

            _playerAnimationEvents.OnThrowFinished -= HandleThrowFinished;

            _playerGroundCheck.OnJustLanded -= HandleLand;

            _playerHealth.OnHealthChanged -= _UIHealth.UpdateHealth;
        }

        private void OnDestroy()
        {
            _playerInputs.Deinitialize();            
        }

        private void HandlePlayerDirection()
        {
            _playerFacing.FlipPlayer(_playerInputs.Direction);
            _playerAnimations.SetPlayerDirection(_playerFacing.IsFacingRight ? 1f : -1f);
        }

        private void HandleJump()
        {
            _playerGravity.UpdateGravity();
            _playerGroundCheck.UpdateGroundedState();

            if (_playerFsm.CurrentState == PlayerState.Damaged) return;          
                        
            if (_playerInputs.JumpReleased && !_playerGroundCheck.IsGrounded)
                _playerJump.CutJump();

            if (_playerInputs.JumpPressed && _playerJump.CanJump)
            {
                _playerJump.Jump();
                _playerAnimations.SetJumpAnimation(true);       
            }
        }

        private void HandleLand()
        {
            _playerAnimations.SetJumpAnimation(false);        
        }

        private void HandleThrow()
        {
            if (_playerFsm.CurrentState == PlayerState.Damaged) return;

            if (!_playerInputs.ThrowPressed || !_playerThrow.CanThrow) return;

            _playerAnimations.SetThrowAnimation(true);
        }
        private void HandleThrowMovement()
        {
            float throwMovement;

            if (!_playerGroundCheck.IsGrounded)
                throwMovement = (int)ThrowMovement.Jump;
            else if (_playerInputs.Direction != 0)
                throwMovement = (int)ThrowMovement.Run;
            else
                throwMovement = (int)ThrowMovement.Idle; 

            _playerAnimations.SetThrowMovement(throwMovement);
        }
        private void HandleThrowFinished()
        {
            _playerThrow.Throw(_playerFacing.IsFacingRight ? 1 : -1, _rb.linearVelocity);

            _playerAnimations.SetThrowAnimation(false);
        }

        private void HandleMovement()
        {
            if (_playerFsm.CurrentState == PlayerState.Damaged) return;

            _playerMovement.Move(_playerInputs.Direction);

            _playerAnimations.SetMoveAnimation(_playerInputs.Direction != 0);
        }

        private void HandleDeath()
        {
            if (_playerHealth.CurrentHealth > 0) return;

            PlayerDoll doll = Instantiate(_doll);

            if (!_playerFacing.IsFacingRight)
                doll.SetLeftAnimation();
            else
                doll.SetRightAnimation();

            this.gameObject.SetActive(false);


        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageProvider damageProvider))
            {
                float damageDirection = this.transform.position.x - collision.transform.position.x;

                _playerCollisionHandler.HandleDamageCollision(collision.gameObject, damageProvider, damageDirection);                
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IPickable pickable))
            {
                _playerCollisionHandler.HandlePickableCollision(pickable);
            }
        }

        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }
    }
}


