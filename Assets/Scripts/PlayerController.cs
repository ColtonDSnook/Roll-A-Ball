using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private int count;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  //x
        float moveVertical = Input.GetAxis("Vertical"); //y
        Vector3 movement = new Vector3();

        int rotationSwitch = CameraController.rotPosition;

        switch (rotationSwitch)
        {

            case 0:
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                break;

            case 1:
                movement = new Vector3(moveVertical, 0.0f, -1 * moveHorizontal);
                break;

            case 2:
                movement = new Vector3(moveHorizontal * -1, 0.0f, moveVertical * -1);
                break;

            case 3:
                movement = new Vector3(moveVertical * -1, 0.0f, moveHorizontal);
                break;
        }

        rb.AddForce(movement * speed);

        if (this.transform.position.y <= -20)
        {
            this.transform.position = new Vector3(0, 5, 0);
            count = 0;
            
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
}
