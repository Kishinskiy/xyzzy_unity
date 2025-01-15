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

    private void Awake()
    {
	    _rigidbody = GetComponent<Rigidbody2D>();
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
	    if (isJumping)
	    {
		    if (IsGrounded())
		    {
			    _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		    } 
		    //else if (_rigidbody.velocity.y > 0)
		    //{
			//    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
		    //}
		    // Отключил это условие: так как высота прыжка либо слишком мала: либо случайным образом отрабатывает на максимальную высоту.
		    
	    }
    }
}
