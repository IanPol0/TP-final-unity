
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    public GameObject bala;

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }

}