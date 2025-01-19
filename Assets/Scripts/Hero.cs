 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private LayerCheck _groundCheck;
    
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
	    _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
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
	    _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
	    var isJumping = _direction.y > 0;
	    var isGrounded = IsGrounded();
	    if (isJumping)
	    {
		    if (isGrounded)
		    {
			    _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		    }
		    //else if (_rigidbody.velocity.y > 0)
		    //{
		    //    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
		    //}
		    // Это условие ломает весь прыжок. В итоге высата прыжка слижком низкая, но в какой то моент условие срабатывает и высата прыжка становится маскимальной.
		    // без этого условия лучше.
	    }
	    _animator.SetBool("IsGround", isGrounded);
	    _animator.SetFloat("VericalVelocity", _rigidbody.velocity.y);
	    _animator.SetBool("Is_Running", _direction.x != 0);
    }
}
