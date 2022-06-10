using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifesManagerj1 : MonoBehaviour
{
    int vidas = 3;
    float elapsedTime;
    public Text vidasRojo;
    public GameObject panel;
    public GameObject BolaAzul;

    public Material Rojo;
    public Material Rosa;

    bool recibedaño;

    void Start()
    {
        panel.SetActive(false);
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 3)
        {
            gameObject.GetComponent<Renderer>().material = Rojo;
            recibedaño = true;
        }

        if (vidas == 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);

            while(elapsedTime <3)
            {
                GameObject bolaCelebracionClon = Instantiate(BolaAzul);
                Destroy(bolaCelebracionClon, 5);
            }
        }

        vidasRojo.text = "Vidas: " + vidas;

        if (gameObject.transform.position.y < -3 && elapsedTime > 3)
        {
            vidas--;
            elapsedTime = 0;
            
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && elapsedTime > 3)
        {
            vidas--;
            elapsedTime = 0;
            gameObject.GetComponent<Renderer>().material = Rosa;
            recibedaño = false;
        }
    }
}
