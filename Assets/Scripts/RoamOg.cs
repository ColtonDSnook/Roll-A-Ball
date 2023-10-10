using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

public class RoamOg : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int minIndex = 0;
    int maxIndex = 5;
    int waypointIndex;
    Vector3 target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        int randomIndex = Random.Range(minIndex, maxIndex);
        if (waypointIndex != randomIndex)
        {
            waypointIndex = randomIndex;
        }
    }
}
