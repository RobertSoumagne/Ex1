using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Goal : MonoBehaviour
{
    public GameObject winnertext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winnertext.SetActive(true);
        }
        
    }
}
