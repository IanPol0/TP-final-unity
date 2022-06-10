using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifesManagerj2 : MonoBehaviour
{
    int vidas = 3;
    float elapsedTime;
    public Text vidasAzul;
    public GameObject panel;
    public GameObject BolaRoja;

    public Material Azul;
    public Material Celeste;

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
            gameObject.GetComponent<Renderer>().material = Azul;
        }
        if (vidas == 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);

            while(elapsedTime < 3)
            {
                GameObject bolaCelebracionClon = Instantiate(BolaRoja);
                Destroy(bolaCelebracionClon, 5);
            }
        }

        

        if (gameObject.transform.position.y < -3 && elapsedTime >3)
        {
            vidas--;
            elapsedTime = 0;
        }
        
        vidasAzul.text = "Vidas: " + vidas;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && elapsedTime > 3)
        {
            vidas--;
            elapsedTime = 0;
            gameObject.GetComponent<Renderer>().material = Celeste;
        }
    }
}
