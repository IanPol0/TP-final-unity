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
    float TiempoRecargando;

    bool hasJump = true;
    bool isCounting = false;

    Rigidbody rb;

    AudioSource sounds;
    public AudioClip shootingSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sounds = GetComponent<AudioSource>();
    }

    void Update()
    {
        balasRestantes.text = "" + BulletsLeft;

        if (Input.GetKey(KeyCode.W)) // Avanzar
        {
            transform.Translate(0, 0, 0.2f);
        }
        if (Input.GetKey(KeyCode.S)) //Retroceder
        {
            transform.Translate(0, 0, -0.2f);
        }
        if (Input.GetKey(KeyCode.D)) //Rotar para derecha
        {
            transform.Rotate(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.A)) //Rotar para izquierda
        {
            transform.Rotate(0, -5, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && hasJump) //Saltar
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && BulletsLeft>0) //Disparar
        {
            sounds.clip = shootingSound;
            sounds.Play(0);

            GameObject balaClon = Instantiate(bala, canion.transform.position + transform.forward * 1, canion.transform.rotation);
            Rigidbody rbBalaClon = balaClon.GetComponent<Rigidbody>();
            rbBalaClon.AddForce(transform.forward * fuerza, ForceMode.Impulse);
            Destroy(balaClon, 3);

            BulletsLeft--;

            if(BulletsLeft == 0) //Si el jugador se queda sin balas, empieza a contar
            {
                isCounting = true;
            }
        }

        if (isCounting) //Si esta contando
        {
            balasRestantes.text = Mathf.Floor(TiempoRecargando).ToString(); //Se muestra en el texto los segundos que faltan para volver a disparar
            TiempoRecargando += Time.deltaTime; //Se cuentan los segundos que pasaron desde que se quedo sin balas

            if (TiempoRecargando > 5.1) //Si ya pasaron 5 segundos
            {
                BulletsLeft = 15; //Se reinicia la cantidad de balas
                isCounting = false; //Se deja de contar
                TiempoRecargando = 0; //Se reinicia el tiempo que paso para la proxima que el jugador se quede sin balas
            }
        }

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(0, 3, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground") //Solo cuando el jugador toque el piso
        {
            hasJump = true; //Va a poder volver a saltar
        }
    }
}