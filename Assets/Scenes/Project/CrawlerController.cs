using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CrawlerController : MonoBehaviour
{

    public Rigidbody rgBod;
    public Animator anime;
    private NavMeshAgent navAgent;
    public float range;
    public float deathrange;
    private Transform plaver;
    public int deathCount;
    public Animator fader;
    private AudioSource audio;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anime = GetComponent<Animator>();
    }

    private void end()
    {
        fader.SetInteger("state", 1);

    }

    private void kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathCount++;
        PlayerPrefs.SetInt("DeathCount", deathCount);
        Debug.Log(deathCount);
    }

    public void ResetDeathCount()
    {
        PlayerPrefs.DeleteKey("DeathCount");
        deathCount = 0;
        PlayerPrefs.SetInt("DeathCount", deathCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        plaver = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent.destination = transform.position;
        InvokeRepeating("SearchForPlayer", 0, 0.5f);
        deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        audio = GetComponent<AudioSource>();

    }

    private void SearchForPlayer()
    {
        if (Vector3.Distance(transform.position, plaver.position) < range)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, plaver.position - transform.position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    anime.SetInteger("state", 1);
                    navAgent.destination = plaver.position;
                    if (!audio.isPlaying)
                    {
                        audio.Play();
                    }
                    if (Vector3.Distance(transform.position, plaver.position) < deathrange)
                    {
                        Invoke("kill", 1);
                        Invoke("end", 0);
                    }

                    return;
                    
                }   
            }
        }
        anime.SetInteger("state", 0);
        navAgent.isStopped = true;
        navAgent.ResetPath();
        if (audio.isPlaying)
        {
            audio.Stop();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetDeathCount();
        }
    }

}
