using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private LayerMask _groundLayer;
	[SerializeField] private float _groundCheckRadius;
	[SerializeField] private Vector3 _groundCheckPositionDelta;
    
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
	  var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0, _groundLayer);
	  return hit.collider != null;
		
    }

    // DEBUG
    private void OnDrawGizmos()
    {
	    Gizmos.color = IsGrounded() ? Color.green : Color.red;
		Gizmos.DrawSphere(transform.position + _groundCheckPositionDelta, _groundCheckRadius);
    }
    // END DEBUG
    
    private void FixedUpdate()
    {
	    _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
	    var isJumping = _direction.y > 0;
	    if (isJumping && IsGrounded())
	    {
		    _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
	    }
    }
}
