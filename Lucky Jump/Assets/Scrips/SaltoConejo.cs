using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaltoConejo : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public static SaltoConejo instance;
    public GameObject[] textoDinamico;
    public Animator[] animaciones;
    public GameObject topeSuperior;
    public GameObject blackShadowByHitTheFloor;
    public bool isDead = true;
    public bool golpeAbajo = false;
    public bool conejoSalio = false;
    public bool inicioJuego = true;
    public float tiempoInicio = 0.0f;
    bool banningFallingAnimation = true;
    public bool secundaryPlatformActive = true;
    public bool justOneJumpChecker = true;
    public bool callingJump = false;

    Animator anim;

    public float velPlat = -15f;

    private void Awake()
    {
        SaltoConejo.instance = this;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
        if (isDead) return;

        if ((TouchPad.instance.pulsado == true || Input.GetKeyDown("space")) && justOneJumpChecker == true)
        {
            HittingPlatform();
        }

        if(callingJump == true)
        {
            SaltoConejoAutomatico();
        }

            if(conejoSalio == true)
        {
            tiempoInicio += Time.deltaTime;
            if (tiempoInicio >= 3.6f)  textoDinamico[0].SetActive(true); 
            if (tiempoInicio >= 4.4f)  textoDinamico[1].SetActive(true);
            if (tiempoInicio >= 5.2f)
            {
                textoDinamico[2].SetActive(true);
            }
            if (tiempoInicio >= 6.0f)
            {
                secundaryPlatformActive = false;
            }
        }
    }

    public void HittingPlatform()
    {
        PlataformaInicial.instance.starPlatformContact = true;
        if (banningFallingAnimation == false) ConejoHaciaAbajo();
        inicioJuego = false;
        justOneJumpChecker = false;
    }

    // *******************************************************************************************

    public void ConejoHaciaAbajo()
    {
        if (isDead) return;
        rb2d.velocity = Vector2.down * 300; //caida de 200 por defecto
        rb2d.gravityScale = 1f;
        golpeAbajo = true;
        Contador();
        CallAnimationFallingFaster();
        
    }

    public void Contador()
    {
        animaciones[0].Play("contador", -1, 0f);
        animaciones[1].Play("contador2", -1, 0f);
        animaciones[2].Play("contador3", -1, 0f);
        textoDinamico[0].SetActive(false);
        textoDinamico[1].SetActive(false);
        textoDinamico[2].SetActive(false);
        tiempoInicio = 0.0f;
        CallAnimationFallingFaster();
        //conejoSentado = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "plat1")
        {
            anim.SetTrigger("toHittingFloor");  
        }

        if(other.gameObject.tag == "platCommon" && isDead == false)
        {
            anim.SetTrigger("toHittingFloor");
            //SaltoConejoAutomatico();
        }

        if (other.gameObject.tag == "topCollision")
        {
            anim.SetTrigger("onTop");
            callingJump = false;
        }
        if (other.gameObject.tag == "finalCollision")
        {
            SetFinalAnimation();
        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "plat1" || other.gameObject.tag == "platCommon")
        {
            anim.SetTrigger("toJumpCharacter");
            banningFallingAnimation = false;
        }
    }



    public void IniciacionHilos()
    {
        PlataformaInicial.instance.ScrollingPlataformaInicial();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("plat1"))
        {
            PausarHilos();
        }
    }

    public void PausarHilos()
    {
        MovimientoFuncionPlatAltern.intance.ScrollingPlatAltStop();
    }

    public void SaltoConejoAutomatico()
    {
        Debug.Log("Si se activo el salto");
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, 1500)); //subida de 1500 por defecto
        
        rb2d.gravityScale = 0.01f;
        IniciacionHilos();
        ControladorJuego.instance.gameOver = false;
        
        
    }


     void SetFinalAnimation()
    {
        if(ControladorJuego.instance.puntos < PlayerPrefs.GetInt("MaxScore"))
        {
            anim.SetTrigger("toLosing");
        }
        else if(ControladorJuego.instance.puntos  == PlayerPrefs.GetInt("MaxScore"))
        {
            anim.SetTrigger("toDrawing");
        }

    }
    void CallAnimationFallingFaster()
    {
        anim.SetTrigger("toFallFaster");
    }
    void CallAnimationIdle()
    {
        anim.SetTrigger("toIdleCharacter");
    }

    public void JumpFirstTimeInvokation()
    {
        rb2d.velocity = Vector2.down * 50;
        CallAnimationFallingFaster();
        Invoke("CallAnimationIdle", 1f);
        Invoke("SaltoConejoAutomatico", 2f);
        
    }
    public void JumpSecondTimeInvokation()
    {
        rb2d.velocity = Vector2.down * 50;
        CallAnimationFallingFaster();
        Invoke("SaltoConejoAutomatico", 0.5f);
    }
}
