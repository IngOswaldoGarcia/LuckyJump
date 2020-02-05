using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovimientoFuncionPlatAltern : MonoBehaviour {

    public static MovimientoFuncionPlatAltern instance;
    private Rigidbody2D rb2d;
    public Animator animAdicionScore;
   // public GameObject objetoAnimation;
    public AudioSource sonidoPunto;
    public static MovimientoFuncionPlatAltern intance;
    public float timeVelocity = 0;
    public int puntosPorPlataforma = 0;
    public int incrementoPuntos = 0;
    int up10 = 0, up20 = 0, up50 = 0, up100 = 0;
    bool inspectorDeVelocidad = true;
    public bool velScroll = false;
    bool antiDoublePoint = true;
    public float tiempoConteo = 0;
    float ScreenLimitSizeLeft = 0, screenLimitSizeRight = 0;
    float normalVelocity = 0;
    public GameObject SecundaryPlatformColliderBug;
    

    private void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        MovimientoFuncionPlatAltern.intance = this;
        MovimientoFuncionPlatAltern.instance = this;
    }
    void Start()
    {
        UpdateBoundary();
    }

    void UpdateBoundary()
    {
        Vector2 half = ScreenSet.GetDimensionsInWorldUnits() / 2;
        ScreenLimitSizeLeft = -4.25f;
        screenLimitSizeRight = 4.25f; 
         Debug.Log(half);
        Debug.Log(half.x / 2.3f);
        normalVelocity = -5;
        timeVelocity = normalVelocity;
        Debug.Log(timeVelocity);
    }

    void FixedUpdate()
    {
        if (SaltoConejo.instance.conejoSalio == true && SaltoConejo.instance.isDead == false /*&& SaltoConejo.instance.golpeAbajo == false*/)
        {
            rb2d.velocity = new Vector3(timeVelocity, 0,0);
        }
    }
    private void Update()
    {

        if (rb2d.transform.position.x < ScreenLimitSizeLeft)
        {
            rb2d.transform.position = new Vector3(screenLimitSizeRight, Random.Range(-4f, -5.9f),-1);
            antiDoublePoint = true;
            SaltoConejo.instance.justOneJumpChecker = true;
            SecundaryPlatformColliderBug.SetActive(false);
            if (inspectorDeVelocidad == false)
            {
                puntosPorPlataforma = 0;
                incrementoPuntos = 0;
                timeVelocity = normalVelocity;
                velScroll = false;
                SoundSystem.instance.audioSourceMusic.pitch = 1;
                CloudsMovement.instance.ResetSpeed();
                if (ScrollParallax.instance.incremento != 0.15f) ScrollParallax.instance.StartCoroutine("DecrementBackGroundVel");
            }
            if(SaltoConejo.instance.secundaryPlatformActive ==  false)
            {
                GameObject.FindGameObjectWithTag("platCommon").SetActive(false);
                SaltoConejo.instance.ConejoHaciaAbajo();
            }
            inspectorDeVelocidad = false;
        }
    }

    //PARA QUE LA PLATAFORMA SE PARE
    private void OnCollisionEnter2D(Collision2D other)
    {
        {
            if (other.gameObject.tag == "Player" && SaltoConejo.instance.isDead == false && antiDoublePoint == true)
            {
                Debug.Log("Se hizo contacto con la plataforma secundaria");
                CallingIncrementsPointsNVelocity();
                tiempoConteo += Time.deltaTime;
                animAdicionScore.Play("AnimPuntajeAñadido", -1, 0f);
                SaltoConejo.instance.rb2d.velocity = Vector2.zero;
                ControladorJuego.instance.GanarPuntos();
                SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
                inspectorDeVelocidad = true;
                velScroll = true;
                PuntosPlat.instance.ActualizarMecador();
                SaltoConejo.instance.tiempoInicio = 0;
                //SaltoConejo.instance.SaltoConejoAutomatico();
                SaltoConejo.instance.callingJump = true;
                SaltoConejo.instance.secundaryPlatformActive = true;
                SecundaryPlatformColliderBug.SetActive(true);
                //PlayerPrefs.SetInt("MaxScore", 0);
            }
            antiDoublePoint = false;
        }
}

    public void ScrollingPlatAltStop()
    {
        rb2d.velocity = Vector2.zero;
    }

    void CallingIncrementsPointsNVelocity()
    {
        incrementoPuntos++;
        puntosPorPlataforma = incrementoPuntos;
        
        if (incrementoPuntos < 10)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            ScrollParallax.instance.IncrementarVelFondo();
            timeVelocity--;
            SoundSystem.instance.audioSourceMusic.pitch += 0.02f;
        }
        if (incrementoPuntos >= 10 && incrementoPuntos <= 19)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 10;
            if (incrementoPuntos == 10)
            {
                timeVelocity -= 2;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
        if (incrementoPuntos >= 20 && incrementoPuntos <= 29)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 20;
            if (incrementoPuntos == 20)
            {
                timeVelocity -= 2;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
        if (incrementoPuntos >= 30 && incrementoPuntos <= 39)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 50;
            if (incrementoPuntos == 30)
            {
                timeVelocity -= 2;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
        if (incrementoPuntos >= 40 && incrementoPuntos <= 49)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 100;
            if (incrementoPuntos == 40)
            {
                timeVelocity -= 2;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
        if (incrementoPuntos >= 50 && incrementoPuntos <= 59)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 200;
            if (incrementoPuntos == 50)
            {
                timeVelocity -= 2;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
        if (incrementoPuntos >= 60 && incrementoPuntos <= 69)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 500;
            if (incrementoPuntos == 60)
            {
                timeVelocity -= 2;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
        if (incrementoPuntos >= 70 && incrementoPuntos < 100)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 1000;
            if (incrementoPuntos == 70)
            {
                timeVelocity -= 5;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
        if (incrementoPuntos >= 100)
        {
            //SoundSystem.instance.PlaySoundHittingSecundaryPlatform();
            puntosPorPlataforma = 10000;
            if (incrementoPuntos == 100)
            {
                timeVelocity -= 5;
                ScrollParallax.instance.IncrementarVelFondo();
                SoundSystem.instance.audioSourceMusic.pitch += 0.05f;
                SoundSystem.instance.PlaySoundHittingSecundaryPlatformHigherScore();
            }
        }
    }

}
