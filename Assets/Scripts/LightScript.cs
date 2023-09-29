using UnityEngine;

public class DisablePickUp : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject[] pickUpObjects;
    public float disableDistance = 20f;

    private void Update()
    {
        if (playerObject == null)
        {
            Debug.LogWarning("PlayerObject not assigned in the inspector.");
            return;
        }

        foreach (var pickUpObject in pickUpObjects)
        {
            if (pickUpObject == null)
            {
                Debug.LogWarning("PickUpObject not assigned in the inspector.");
                continue;
            }

            float distance = Vector3.Distance(playerObject.transform.position, pickUpObject.transform.position);

            if (distance > disableDistance)
            {
                pickUpObject.SetActive(false);
            }
            else
            {
                pickUpObject.SetActive(true);
            }
        }
    }
}