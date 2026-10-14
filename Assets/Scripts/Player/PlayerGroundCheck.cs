using UnityEngine;
using System;
using Game.Data;

public class PlayerGroundCheck 
{
    private readonly Transform _groundCheck;
    private readonly float _groundCheckDistance;
    private readonly LayerMask _groundLayer;
    private readonly Vector2 _groundCheckSize;

    public event Action OnJustLanded;

    private bool _isGroundedPreviousState;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;
    
    public PlayerGroundCheck(Transform groundCheck, PlayerConfigSo data)
    {
        _groundCheck = groundCheck;
        _groundCheckDistance = data.groundCheckDistance;
        _groundLayer = data.GroundLayer;
        _groundCheckSize = data.GroundCheckSize;

        _isGrounded = true;
        _isGroundedPreviousState = _isGrounded;
    }

    public void UpdateGroundedState()
    {
        _isGrounded = Physics2D.BoxCast(_groundCheck.position,_groundCheckSize, 0, Vector3.down,
            _groundCheckDistance, _groundLayer);

        if (_isGrounded != _isGroundedPreviousState)
        {
            if(_isGrounded)
                OnJustLanded?.Invoke();

            _isGroundedPreviousState = _isGrounded;
        }
    }
}
