using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movMult;
    public float turnMult;
    public float JumpMult;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * movMult, 0, Input.GetAxis("Vertical") * movMult);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnMult);

        if(Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * JumpMult);
        }
    }
}
