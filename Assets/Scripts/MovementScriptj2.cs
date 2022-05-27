using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptj2 : MonoBehaviour
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow) && hasJump)
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && hasJump)
        {
            transform.Rotate(0, -5, 0);
        }

        if (Input.GetKeyDown(KeyCode.P) && hasJump) //SALTO
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            hasJump = true; ;
        }
        
        if (col.gameObject.name == "LastGround")
        {
            transform.position = new Vector3 (1, 0.5f, 0);
        }
    }

}