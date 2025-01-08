using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float _speed;
    
    private Vector2 _direction;
    

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SaySomething()
    {
	    Debug.Log("Pressed Action Button!");
    }

    private void Update()
    {
       if (_direction.x != 0 || _direction.y != 0)
		{
			var deltaX = _direction.x * _speed * Time.deltaTime;
			var deltaY = _direction.y * _speed * Time.deltaTime;
			var newXPosition = transform.position.x + deltaX;
			var newYPosition = transform.position.y + deltaY;
			transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
		}
    }
}
