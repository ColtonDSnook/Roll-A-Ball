using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Sam Robichaud 2022
// NSCC-Truro
// Based on tutorial by (Comp - 3 Interactive)  * with modifications *



public class FirstPersonController : MonoBehaviour
{
    public bool canMove { get; private set; } = true;
    private bool isRunning => canRun && Input.GetKey(runKey);



    #region Settings



    [Header("Functional Settings")]
    [SerializeField] private bool canRun = true;





    [Header("Controls")]
    [SerializeField] private KeyCode runKey = KeyCode.LeftShift;



    [Header("Move Settings")]
    [SerializeField] private float walkSpeed = 4.0f;
    [SerializeField] private float runSpeed = 10.0f;



    [Header("Look Settings")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 70.0f;
    [SerializeField, Range(-180, 1)] private float lowerLookLimit = -70.0f;
    #endregion



    private Camera playerCamera;
    private CharacterController characterController;



    private Vector3 moveDirection;
    private Vector2 currentInput;



    private float rotationX = 0;



    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();




        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    private void Update()
    {
        if (canMove)
        {
            HandleMovementInput();
            HandleMouseLook(); // look into moving into Lateupdate if motion is jittery
        }
    }







    private void HandleMovementInput()
    {
        // Read inputs
        currentInput = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxis("Horizontal"));



        // normalizes input when 2 directions are pressed at the same time
        // TODO; find a more elegant solution to normalize, this is a bit of a hack method to normalize it estimates and is not 100% accurate.
        currentInput *= (currentInput.x != 0.0f && currentInput.y != 0.0f) ? 0.7071f : 1.0f;



        // Sets the required speed multiplier
        currentInput *= (isRunning ? runSpeed : walkSpeed);



        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }



    private void HandleMouseLook()
    {
        // Rotate camera up/down
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, lowerLookLimit, upperLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);



        // Rotate player left/right
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);



    }
}