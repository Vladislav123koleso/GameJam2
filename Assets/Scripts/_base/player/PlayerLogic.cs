using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    float speed = 15.0f; // скорость
    public Vector3 jump;
    public float jumpForce = 10.0f;
    public bool isGrounded;
    Rigidbody rb;
    float ang = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 10.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }


    }
}
