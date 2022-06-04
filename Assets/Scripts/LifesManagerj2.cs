using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifesManagerj2 : MonoBehaviour
{
    int vidas = 3;
    public Text vidasAzul;
    public GameObject panel;
    public GameObject BolaRoja;

    void Start()
    {
        panel.SetActive(false);
    }


    void Update()
    {
        if (vidas == 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);
            for (int i = 0; i < 300; i++)
            {
                GameObject bolaCelebracionClon = Instantiate(BolaRoja);
                Destroy(bolaCelebracionClon, 3);
            }
        }

        vidasAzul.text = "Vidas: " + vidas;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            vidas--;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "LastGround")
        {
            vidas--;
        }
    }
}
