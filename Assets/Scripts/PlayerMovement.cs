using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movMult;
    public float turnMult;
    public float jumpMult;
    Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal") * movMult;
        float moveZ = Input.GetAxis("Vertical") * movMult;
        transform.Translate(moveX, 0, moveZ);

        // Camera Rotation: Separate Mouse and Controller Input
        float mouseX = Input.GetAxis("Mouse X") * turnMult;  // Mouse movement
        float controllerX = Input.GetAxis("RightStickX") * turnMult; // Controller Right Stick (custom mapping)

        // Use controller input only if it's not zero (avoiding conflict with Mouse X)
        float rotation = Mathf.Abs(controllerX) > 0.1f ? controllerX : mouseX;
        transform.Rotate(Vector3.up * rotation);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpMult, ForceMode.Impulse);
        }
    }
}
