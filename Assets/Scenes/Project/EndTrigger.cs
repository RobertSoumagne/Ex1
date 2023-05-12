using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    public Animator fader;
    public GameObject winner;

    private void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void end()
    {
        fader.SetInteger("state", 1);

    }


    private void winnerText()
    {
        winner.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {



        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().AddForce(-10*Physics.gravity, ForceMode.Acceleration);
            other.GetComponent<PlayerController>().enabled = false;
            Invoke("end", 3);
            Invoke("winnerText", 4);
            Invoke("reset", 10);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
