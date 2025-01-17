using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components
{
    public class IncraseScoreComponent : MonoBehaviour
    {
        [SerializeField] private GameController _controller;
        [SerializeField] private int _score;

        public void IncraseScore()
        {
            _controller.IncraseScore(_score);
        }

        

        
    }
    
}
