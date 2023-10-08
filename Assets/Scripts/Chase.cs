using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseAI : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float chaseDistance = 10.0f; // Maximum distance to start chasing
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false; // Optional: To control rotation manually
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the player is within the chase distance
            if (distanceToPlayer <= chaseDistance)
            {
                // Set the destination to the player's position
                navMeshAgent.SetDestination(player.position);
            }
            else
            {
                // Stop chasing when the player is out of range
                navMeshAgent.ResetPath();
            }
        }
    }
}