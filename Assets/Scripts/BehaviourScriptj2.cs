using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourScriptj2 : MonoBehaviour
{

    public float jumpForce;
    public float fuerza;

    public GameObject canion;
    public GameObject bala;
    public Text balasRestantes;

    int bulletsLeft = 15;

    bool hasJump = true;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        balasRestantes.text = "" + bulletsLeft;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 0.2f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -0.2f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -5, 0);
        }

        if (Input.GetKeyDown(KeyCode.P) && hasJump) //SALTO
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump = false;
        }

        if (Input.GetKeyDown(KeyCode.L) && bulletsLeft>0)
        {
            GameObject balaClon = Instantiate(bala, canion.transform.position + transform.forward * 1, canion.transform.rotation);
            Rigidbody rbBalaClon = balaClon.GetComponent<Rigidbody>();
            rbBalaClon.AddForce(transform.forward * fuerza, ForceMode.Impulse);
            Destroy(balaClon, 3);

            bulletsLeft--;
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
            transform.position = new Vector3 (0, 1, 0);
        }
    }

}