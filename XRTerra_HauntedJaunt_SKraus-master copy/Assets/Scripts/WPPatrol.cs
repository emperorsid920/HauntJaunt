using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WPPatrol : MonoBehaviour
{

    public Transform[] waypoints;

    NavMeshAgent navMeshAgent;

    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            currentIndex++;
            currentIndex %= waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentIndex].position);
        }
    }
}
