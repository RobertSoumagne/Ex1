using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private int pos = 0;
    public Transform[] goal;
    public GameObject player;
    public float detectRadius;
    public GameObject loosertext;
    public float looseradius;

    public bool playerDetected;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal[0].position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        //checks if player is in range
        if ( distance <= detectRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }


        if (distance <= looseradius)
        {
            loosertext.SetActive(true);
        }



        // once the agent reaches the goal, it will go to the next goal

        if (agent.remainingDistance < 0.5f && playerDetected == false)
        {
            pos++;
            pos %= goal.Length;
            agent.destination = goal[pos].position;
            
        }
        // if the player is detected, the agent will go to the player's position
        else if (playerDetected == true)
        {
            agent.destination = player.transform.position;
        }

    }
}