using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueConPiso : MonoBehaviour {

    public static ChoqueConPiso instance;

    public AudioSource audio1;
    public GameObject conejo;

    private void Awake()
    {
        ChoqueConPiso.instance = this;
        audio1 = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SaltoConejo.instance.PausarHilos();
            Debug.Log("Se hizo contacto con el suelo");
            ControladorJuego.instance.GameOver();
            SaltoConejo.instance.isDead = true;
            
            SaltoConejo.instance.rb2d.velocity = Vector2.zero;
            SaltoConejo.instance.conejoSalio = false;
            SaltoConejo.instance.rb2d.gravityScale = 1f;
            SoundSystem.instance.PlaySoundHittingFinalPlatform();
            SoundSystem.instance.StopGamePlayMusic();

            // conejo.SetActive(false);

            //SonidoGolpe();
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Conejo")
        {
            SaltoConejo.instance.rb2d.velocity = Vector2.zero;
           // SaltoConejo.instance.rb2d.velocity = Vector2.down *100;
        }
    }
    */
    public void SonidoGolpe()
    {
        audio1.Play();
    }
}
