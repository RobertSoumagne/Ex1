using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bucketcollider : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI text;

    public int Score { get => score;
        set
        {
            score = value;
            text.text = score.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Score++;
    }

}
