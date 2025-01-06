using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputReader : MonoBehaviour
{
    private Hero _hero;
    private void Awake()
    {
       _hero = GetComponent<Hero>();
    }
    
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        _hero.SetDirection(horizontal);
    }
}
