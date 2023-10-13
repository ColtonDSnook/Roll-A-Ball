using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDeath : MonoBehaviour

{
    public TextMeshProUGUI loseText;
    public Rigidbody playerRigidbody;
    public GameObject gameoverObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Game over
            loseText.gameObject.SetActive(true);
            // Deactivate player and return mouse control
            GameObject.Find("FirstPersonController").active = false;
            Cursor.lockState = CursorLockMode.None;
            gameoverObject.SetActive(true);
        }
    }
}
