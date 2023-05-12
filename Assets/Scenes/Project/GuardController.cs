using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardController : MonoBehaviour
{

    public Animator anime;
    private Transform plaver;
    public int deathCount;
    public Animator fader;
    private AudioSource audio;

    private void Awake()
    {
        anime = GetComponent<Animator>();
    }

    private void end()
    {
        fader.SetInteger("state", 1);

    }

    public void ResetDeathCount()
    {
        PlayerPrefs.DeleteKey("DeathCount");
        deathCount = 0;
        PlayerPrefs.SetInt("DeathCount", deathCount);
    }

    private void kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathCount++;
        PlayerPrefs.SetInt("DeathCount", deathCount);
        Debug.Log(deathCount);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        
        if (other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerController>().isJumping)
        {
            Debug.Log("Dead");
            anime.SetInteger("state", 1);
            Invoke("end", 0.5f);
            Invoke("kill", 1.5f);
            return;

        }
        anime.SetInteger("state", 0);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        plaver = GameObject.FindGameObjectWithTag("Player").transform;
        deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetDeathCount();
        }
    }
}
