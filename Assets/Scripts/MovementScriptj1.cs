using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptj1 : MonoBehaviour
{
    public float jumpForce;

    bool hasJump = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.1f);
        }
        if (Input.GetKey(KeyCode.D) && hasJump)
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.A) && hasJump)
        {
            transform.Rotate(0, -5, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && hasJump) //SALTO
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            hasJump = true;
        }

        if (col.gameObject.name == "LastGround")
        {
            transform.position = new Vector3(-1, 0.5f, 0);
        }
    }
}