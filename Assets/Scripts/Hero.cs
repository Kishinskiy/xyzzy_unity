using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
    
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

    private void FixedUpdate()
    {
	    _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
	    var isJumping = _direction.y > 0;
	    if (isJumping)
	    {
		    _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
	    }
    }
}
