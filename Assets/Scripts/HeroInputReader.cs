﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;
 public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
       _hero.SetDirection(direction.x, direction.y);
    }

    public void OnSayAction(InputAction.CallbackContext context)
    {
       if (context.canceled)
       {
          _hero.SaySomething();
       }
       
    }
}
