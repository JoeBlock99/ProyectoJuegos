using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrulla : MonoBehaviour
{

    public GameObject[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool patrol = true;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {

        if (points.Length == 0)
            return;


        agent.destination = points[destPoint].transform.position;
        destPoint = (destPoint + 1) % points.Length;
    }

    
    void Update()
    {
        if (patrol == true)
        {
            if (agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        else
        {

        }
       
    }
}
