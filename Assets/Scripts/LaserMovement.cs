using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float minX = 0f;
    public float maxX = 10f;
    public float minZ = 0f;
    public float maxZ = 10f;
    public float moveSpeed = 5f;

    private Vector3 targetPosition;

    void Start()
    {
        // Initialize the target position within the specified area
        RandomizeTargetPosition();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the object has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Randomize a new target position within the specified area
            RandomizeTargetPosition();
        }
    }

    void RandomizeTargetPosition()
    {
        // Generate random X and Z coordinates within the specified area
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // Set the target position
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}