using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    public Transform player;
    public RoamState roamState;
    public float chaseDistance = 10.0f;
    [SerializeField]private NavMeshAgent navMeshAgent;

    //private IEnumerator Start()
    //{
        //yield return new WaitForSeconds(30);
        //navMeshAgent.ResetPath();
        //yield return new WaitForSeconds(3);
        //Debug.Log("grr");
        //yield return roamState;
    //}
    public override State RunCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= chaseDistance)
        {
            UpdateEnemy();
        }
        else
        {
            navMeshAgent.ResetPath();
            return roamState;
        }
        return this;
    }
    private void UpdateEnemy()
    {
        navMeshAgent.SetDestination(player.position);
    }
}

