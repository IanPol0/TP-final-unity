
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    public GameObject bala;

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);

        if (col.gameObject.tag == "j1")
        {
            //hace ruidito de colision especifico para j1
        }
        
        if (col.gameObject.tag == "j2")
        {
            //hace ruidito de colision especifico para j2
        }
    }

}