using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject bala;
    PlayerHealth p1;
    PlayerHealth p2;

    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        var P1 = col.gameObject.GetComponent<MovementScriptj1>();
        var P2 = col.gameObject.GetComponent<MovementScriptj2>();

        if (col.gameObject.tag == "j1")
        {
            p1 = col.gameObject.GetComponent<PlayerHealth>();
            p1.vidas--;
            if (p1.vidas == 0)
            {
                Destroy(col.gameObject);
            }
            Debug.Log(p1.vidas);
        }

        if (col.gameObject.tag == "j2")
        {
            p2 = col.gameObject.GetComponent <PlayerHealth>();
            p2.vidas--;
            if (p2.vidas == 0)
            {
                Destroy(col.gameObject);
            }
            Debug.Log(p2.vidas);
        }

        Destroy(gameObject);
    }

}
