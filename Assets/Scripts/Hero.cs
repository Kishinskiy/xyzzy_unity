 using System;
 using System.Collections;
using System.Collections.Generic;
using PixelCrew.Components;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _damageJumpSpeed;
	[SerializeField] private LayerCheck _groundCheck;
	[SerializeField] private float _interactRadius;
	
	[SerializeField] private LayerMask _interactionLayer;
    
    private Collider2D[] _interactResults = new Collider2D[1];
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private bool _isGrounded;
    private bool _allowDoubleJump;

    private static readonly int IsGroundKey = Animator.StringToHash("IsGround");
    private static readonly int VericalVelocityKey = Animator.StringToHash("VericalVelocity");
    private static readonly int Is_RunningKey = Animator.StringToHash("Is_Running");
    private static readonly int Hit = Animator.StringToHash("Hit");
    private void Awake()
    {
	    _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
	    _isGrounded = IsGrounded();
    }

    public void SaySomething()
    {
	    Debug.Log("Pressed Action Button!");
    }

    private bool IsGrounded()
    {
	    return _groundCheck.isTouchingGround;

    }

    // DEBUG
    private void OnDrawGizmos()
    {
	    Gizmos.color = IsGrounded() ? Color.green : Color.red;
		Gizmos.DrawSphere(transform.position, 0.3f);
    }
    // END DEBUG
    
    private void FixedUpdate()
    {
	    var xVelocity = _direction.x * _speed;
	    var yVelocity = CalculateYVelocity();
	    
	    _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
	    
	    
	    _animator.SetBool(IsGroundKey, _isGrounded);
	    _animator.SetFloat(VericalVelocityKey, _rigidbody.velocity.y);
	    _animator.SetBool(Is_RunningKey, _direction.x != 0);
	    
	    UpdateSpriteDirection();
    }

    private float CalculateYVelocity()
    {
	    var yVelocity = _rigidbody.velocity.y;
	    var isJumpingPressing = _direction.y > 0;
	    if (_isGrounded) _allowDoubleJump = true;
	    if (isJumpingPressing)
	    {
		    yVelocity = CalculateJumpVelocity(yVelocity);
	    }
	    else if (_rigidbody.velocity.y > 0)
	    {
		    yVelocity *= 0.5f;
	    }
	    
	    return yVelocity;
    }

    private float CalculateJumpVelocity(float yVelocity)
    {
	    var isFalling = _rigidbody.velocity.y <= 0.001f;
	    if (!isFalling) return yVelocity;
	    if (_isGrounded)
	    {
		    yVelocity += _jumpForce;
	    } else if (_allowDoubleJump)
	    {
		    yVelocity = _jumpForce;
		    _allowDoubleJump = false;
	    }
	    return yVelocity;
    }
    private void UpdateSpriteDirection()
    {
	    if (_direction.x > 0)
	    {
		    _sprite.flipX = false;
	    } else if (_direction.x < 0)
	    {
		    _sprite.flipX = true;
	    }
    }

    public void TakeDamage()
    {
	    _animator.SetTrigger(Hit);
	    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);
    }

    public void Interact()
    {
	    var size = Physics2D.OverlapCircleNonAlloc(transform.position, _interactRadius, _interactResults, _interactionLayer);
	    for (int i = 0; i < size; i++)
	    {
		    var interactable = _interactResults[i].GetComponent<InteractableComponent>();
		    interactable?.Interact();
	    } 
    }
}
