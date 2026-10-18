using UnityEngine;
using System;
using Game.Data;
using Game.Surface;
using Game.Core;

public class PlayerGroundCheck 
{
    private readonly Transform _groundCheck;
    private readonly float _groundCheckDistance;
    private readonly LayerMask _groundLayer;
    private readonly Vector2 _groundCheckSize;

    public event Action OnJustLanded;

    private SurfaceType _currentSurfaceType;
    public SurfaceType CurrentSurfaceType => _currentSurfaceType;

    private bool _isGroundedPreviousState;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;
    
    public PlayerGroundCheck(Transform groundCheck, PlayerConfigSo data)
    {
        _groundCheck = groundCheck;
        _groundCheckDistance = data.groundCheckDistance;
        _groundLayer = data.GroundLayer;
        _groundCheckSize = data.GroundCheckSize;

        _isGroundedPreviousState = _isGrounded;
    }

    public void UpdateGroundedState()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_groundCheck.position, _groundCheckSize, 0, Vector3.down,
            _groundCheckDistance, _groundLayer);

        _isGrounded = hit;

        if (_isGrounded != _isGroundedPreviousState)
        {
            if(_isGrounded)
                OnJustLanded?.Invoke();

            _isGroundedPreviousState = _isGrounded;
        }

        if (hit.collider != null &&  hit.collider.TryGetComponent(out SurfaceIdentifier surface))        
            _currentSurfaceType = surface.SurfaceType;
        
    }
}
