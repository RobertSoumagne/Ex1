using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine;

public class TopDown : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray pos = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(pos, out var hit))
            {
                player.SetDestination(hit.point);
            }
        }
    }
}
