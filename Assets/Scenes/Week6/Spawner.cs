using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float min = -61.4668f;
    public float max = 858.1f;
    public float high = 742.0f;
    public GameObject ball;

    private void spawn()
    {
        Instantiate(ball, new Vector3(Random.Range(min, max), high, 0),Quaternion.identity);
        Invoke("spawn", Random.Range(0.5f, 1));
    }

    void Start()
    {
        Invoke("spawn", Random.Range(0.5f, 1));
    }
}
