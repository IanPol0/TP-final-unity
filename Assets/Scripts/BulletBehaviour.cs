
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    public GameObject bala;
    AudioSource shot;

    void Start()
    {
        shot = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        

        if (col.gameObject.tag == "j1" || col.gameObject.tag == "j2")
        {
            shot.Play(0);
        }

        Destroy(gameObject, 0.5f);
    }

}