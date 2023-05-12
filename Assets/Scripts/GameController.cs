using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private int Score = 0; 

    void OnTriggerEnter()
    {
        Score++; 
        Debug.Log(Score);
    }
}
