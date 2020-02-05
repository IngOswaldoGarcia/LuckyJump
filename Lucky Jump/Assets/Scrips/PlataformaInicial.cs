using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaInicial : MonoBehaviour {

    private Rigidbody2D rb2d;
    public static PlataformaInicial instance;
    public bool starPlatformContact = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlataformaInicial.instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}

    public void ScrollingPlataformaInicial()
    {
        rb2d.velocity = Vector2.right * ControladorJuego.instance.ScrollSpeedPlataformaInicial;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            starPlatformContact = true;
            SaltoConejo.instance.topeSuperior.SetActive(true);
            SaltoConejo.instance.blackShadowByHitTheFloor.SetActive(true);
            Invoke("DisabledShadow", 0.85f);
            SoundSystem.instance.PlaySoundHittingFloor();

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SaltoConejo.instance.conejoSalio = true;
            SaltoConejo.instance.blackShadowByHitTheFloor.SetActive(false);
           // SoundSystem.instance.PlaySoundJump();
            SoundSystem.instance.PlayGamePlayMusic();
        }
    }

    void DisabledShadow()
    {
        SaltoConejo.instance.blackShadowByHitTheFloor.SetActive(false);
    }

}
