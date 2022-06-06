using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifesManagerj1 : MonoBehaviour
{
    int vidas = 3;
    public Text vidasRojo;
    public GameObject panel;
    public GameObject BolaAzul;

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

            for (int i = 0; i<300; i++)
            {
                GameObject bolaCelebracionClon = Instantiate(BolaAzul);
                Destroy(bolaCelebracionClon, 5);
            }
        }

        vidasRojo.text = "Vidas: " + vidas;
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
