using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float _speed;
    private float _directionX;
    private float _directionY;
    

    public void SetDirection(float directionX, float directionY)
    {
        _directionX = directionX;
        _directionY = directionY;
    }

    public void SaySomething()
    {
	    Debug.Log("Pressed Action Button!");
    }

    private void Update()
    {
       if (_directionX != 0 || _directionY != 0)
		{
			var deltaX = _directionX * _speed * Time.deltaTime;
			var deltaY = _directionY * _speed * Time.deltaTime;
			var newXPosition = transform.position.x + deltaX;
			var newYPosition = transform.position.y + deltaY;
			transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
		}
    }
}
