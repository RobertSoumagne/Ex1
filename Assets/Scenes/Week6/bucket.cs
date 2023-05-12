using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bucket : MonoBehaviour
{

    public Slider slider;
    public Transform collider;

    public float initial = -61.4668f;
    public float end = 858.1f;

    

    void Update()
    {
        collider.position = new Vector3(Mathf.Lerp(initial, end, slider.value), collider.position.y, collider.position.z);
        
    }
}
