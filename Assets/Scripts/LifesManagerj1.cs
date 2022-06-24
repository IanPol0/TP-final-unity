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

    AudioSource sounds;
    public AudioClip impactSound;
    public AudioClip SeCaeDelMapa;
    public AudioClip victoria;

    public AudioManager audiomanager;

    void Start()
    {
        panel.SetActive(false);
        sounds = GetComponent<AudioSource>();

    }


    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (vidas == 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);

            sounds.Stop();
            audiomanager.PlaySound(victoria);

            for(int i = 0; i<300; i++)
            {
                GameObject bolaCelebracionClon = Instantiate(BolaAzul);
                Destroy(bolaCelebracionClon, 5);
            }
            
        }

        vidasRojo.text = "Vidas: " + vidas;

        if (gameObject.transform.position.y < -3 && elapsedTime > 3)
        {
            sounds.clip = SeCaeDelMapa;
            sounds.Play();
            vidas--;
            elapsedTime = 0;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && elapsedTime > 3)
        {
            sounds.clip = impactSound;
            sounds.Play();
            vidas--;
            elapsedTime = 0;
        }
    }

}
