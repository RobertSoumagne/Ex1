using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM : MonoBehaviour
{
    public SpriteRenderer back;

    public void Darkmode(bool value)
    {
        if (value)
        {
            back.color = Color.black;
        }
        else
        {
            back.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
