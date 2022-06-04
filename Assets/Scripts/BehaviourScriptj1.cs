using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourScriptj1 : MonoBehaviour
{
    public float jumpForce;
    public float fuerza;

    public GameObject canion;
    public GameObject bala;
    public Text balasRestantes;

    int BulletsLeft = 15;

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
        balasRestantes.text = "" + BulletsLeft;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.2f);
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

        if (Input.GetKeyDown(KeyCode.E) && BulletsLeft>0)
        {
            GameObject balaClon = Instantiate(bala, canion.transform.position + transform.forward * 1, canion.transform.rotation);
            Rigidbody rbBalaClon = balaClon.GetComponent<Rigidbody>();
            rbBalaClon.AddForce(transform.forward * fuerza, ForceMode.Impulse);
            Destroy(balaClon, 3);

            BulletsLeft--;
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
            transform.position = new Vector3(0, 1, -0);
        }
    }
}