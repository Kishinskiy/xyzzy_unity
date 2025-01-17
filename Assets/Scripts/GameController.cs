using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _allScore;
    
    public void IncraseScore(int score)
    {
        _allScore = _allScore + score;
        Debug.Log("you score is " + _allScore);
    }
}
