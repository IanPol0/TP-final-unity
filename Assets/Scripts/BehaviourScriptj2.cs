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
    float TiempoRecargando;

    bool hasJump = true;
    bool isCounting = false;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        balasRestantes.text = "" + bulletsLeft;

        if (Input.GetKey(KeyCode.UpArrow)) //Avanzar
        {
            transform.Translate(0, 0, 0.2f);
        }
        if (Input.GetKey(KeyCode.DownArrow)) //Retroceder
        {
            transform.Translate(0, 0, -0.2f);
        }
        if (Input.GetKey(KeyCode.RightArrow)) //Rotar para derecha
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //Rotar para izquierda
        {
            transform.Rotate(0, -5, 0);
        }

        if (Input.GetKeyDown(KeyCode.P) && hasJump) //Saltar
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump = false;
        }

        if (Input.GetKeyDown(KeyCode.L) && bulletsLeft>0) //Disparar
        {
            GameObject balaClon = Instantiate(bala, canion.transform.position + transform.forward * 1, canion.transform.rotation);
            Rigidbody rbBalaClon = balaClon.GetComponent<Rigidbody>();
            rbBalaClon.AddForce(transform.forward * fuerza, ForceMode.Impulse);
            Destroy(balaClon, 3);

            bulletsLeft--;

            if (bulletsLeft == 0) //Si el jugador se queda sin balas, empieza a contar
            {
                isCounting = true;
            }
        }

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 3, 0);
        }


        if (isCounting) //Si esta contando
        {
            balasRestantes.text = Mathf.Floor(TiempoRecargando).ToString(); //Se muestra en el texto los segundos que faltan para volver a disparar
            TiempoRecargando += Time.deltaTime; //Se cuentan los segundos que pasaron desde que se quedo sin balas

            if (TiempoRecargando > 5.1) //Si ya pasaron 5 segundos
            {
                bulletsLeft = 15; //Se reinicia la cantidad de balas
                isCounting = false; //Se deja de contar
                TiempoRecargando = 0; //Se reinicia el tiempo que paso para la proxima que el jugador se quede sin balas
            }
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground") //Solo cuando el jugador toque el piso
        {
            hasJump = true; //Va a poder volver a saltar
        }
        
        if (col.gameObject.name == "LastGround") //Si el jugador se cae del mapa, 
        {
            transform.position = new Vector3 (0, 1, 0); //Hay una plataforma extra mas abajo que lo hace volver a subir al mapa teletransportandolo
        }
    }

}