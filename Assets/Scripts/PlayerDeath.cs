using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDeath : MonoBehaviour

{
    public TextMeshProUGUI loseText;
    public Rigidbody playerRigidbody;
    public GameObject gameoverObject;
    public GameObject gameovercam;
    public GameObject countText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Game over
            loseText.gameObject.SetActive(true);
            // Deactivate player and return mouse control
            countText.gameObject.SetActive(false);
            gameovercam.SetActive(true);
            GameObject.Find("FirstPersonController").active = false;
            Cursor.lockState = CursorLockMode.None;
            gameoverObject.SetActive(true);
        }
    }
}
