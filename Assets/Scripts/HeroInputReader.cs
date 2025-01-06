using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;
 public void OnHorizaontalMovement(InputValue context)
    {
       var direction =  context.Get<float>();
       _hero.SetDirection(direction);
    }

    public void OnSayAction(InputValue context)
    {
       
          _hero.SaySomething();
       
    }
}
