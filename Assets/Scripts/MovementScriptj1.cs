﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptj1 : MonoBehaviour
{
    public float jumpForce;
    public float fuerza;

    public GameObject canion;
    public GameObject bala;

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
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -5, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && hasJump) //SALTO
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            float rotacionY = canion.transform.rotation.y;
            GameObject balaClon = Instantiate(bala, canion.transform.position + transform.forward * 1, canion.transform.rotation);
            Rigidbody rbBalaClon = balaClon.GetComponent<Rigidbody>();
            rbBalaClon.AddForce(transform.forward * fuerza, ForceMode.Impulse);
            Destroy(balaClon, 3);
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