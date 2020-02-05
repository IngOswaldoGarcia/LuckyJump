using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour {

    public static ControladorJuego instance;

    public float scrollSpeedPinos = -3f;
    public float scrollSpeedPlataformasSecundarias = -10f;
    public float scrollSpeedPinosTraseros = -1.5f;
    public float ScrollSpeedCielo = -0.5f;
    public float ScrollSpeedPlataformaInicial = -10f;
    public bool onMovement;
    public bool gameOver = false;
    public bool pause = false;
    public GameObject MensajeFinal;
    public GameObject colorFondo;
    public GameObject playerCharacter;
    public GameObject plataformaSecundaria;
    public Rigidbody2D animPlataforma;
    public Rigidbody2D animPlataformaFinal;
    //public EdgeCollider2D platformSec;
    public BoxCollider2D platformSec;
    public GameObject mensajePuntos;
    public GameObject activatedWordNew;
    public GameObject loadingScreenGameScene;
    public GameObject pauseScreen;
    public GameObject pauseButton;
    private bool tutorialScreenIsEnabled = false;

    public int puntosPlat = 0;
    private int key = 0;
    private int _puntos = 0;
    public int puntos
    {
        get { return _puntos ^ key; }
        set {
            key = Random.Range(0, int.MaxValue);
            _puntos = value ^ key;
        }
    }

    public Text textoPuntos;

    public Text textoPuntosFinal;



    public Animator anim;
    public Animator finalScore;

    private void Awake()
    {
        ControladorJuego.instance = this;

    }

	// Use this for initialization
	void Start () {
        puntos = 0;
        ActualizarMarcadorPuntos();
        Debug.Log("He Aparecido");
        if (PlayerPrefs.GetInt("OnMenuTrue") != 0)
        {
            DisableTutoFaster();
        }
        else
        {
            PlayerPrefs.SetInt("OnMenuTrue", 1);
        }
    }

    private void Update()
    {
        

        if (Input.GetKeyDown("r"))
        {
            CargarScena();
        }
        
        if (Input.GetKeyDown("n"))
            {

                SceneManager.LoadScene(1);
        }

        if (pause == true) {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if(pause == false){
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public void GameOver()
    {
        gameOver = true;
        textoPuntos.text = "Final Score:\n " + puntos;
        finalScore.SetTrigger("SetFinalScore");
        if (puntos <= PlayerPrefs.GetInt("MaxScore"))
        {
            textoPuntosFinal.text = "Record:\n" + PlayerPrefs.GetInt("MaxScore");
        }
        else
        {
            PlayerPrefs.SetInt("MaxScore", puntos);
            textoPuntosFinal.text = "Record:\n" + PlayerPrefs.GetInt("MaxScore");
            anim.SetTrigger("toWinning");
            activatedWordNew.SetActive(true);
            Social.ReportScore(puntos, "CgkIlLGPi4cYEAIQAQ", (bool success) => { });

        }
        

        MensajeFinal.SetActive(true);
        colorFondo.SetActive(true);
        playerCharacter.transform.position = new Vector3(0, playerCharacter.transform.position.y, -4.7f);
        StartCoroutine("MoverPlat");
        StartCoroutine("MoverPlatFinal");
        SaltoConejo.instance.isDead = true;
        pauseButton.SetActive(false);
        CloudsMovement.instance.ResetSpeed();
    }

    public void ActualizarMarcadorPuntos()
    {
        textoPuntos.text = "Score: " + puntos;  
        if(puntos >= 100000)
        {
            textoPuntos.fontSize = 25;
        }
        if(puntos >= 100000000)
        {
            textoPuntos.fontSize = 20;
        }
    }


    public void GanarPuntos()
    {
        puntos += MovimientoFuncionPlatAltern.intance.puntosPorPlataforma;
       // puntosPlat = MovimientoFuncionPlatAltern.intance.puntosPorPlataforma;
        Instantiate(mensajePuntos, mensajePuntos.transform.position, Quaternion.identity);
        ActualizarMarcadorPuntos();
    }

    public void CargarScena()
    {
        SceneManager.LoadScene(1);
    }



    IEnumerator MoverPlat()
    {
        float posX = animPlataforma.transform.position.x;
        float posY = animPlataforma.transform.position.y;
        platformSec.isTrigger = true;
        for (int i = 0; i < 20; i++)
        {
            animPlataforma.transform.position = (new Vector3(posX,posY-=0.3f, -1));
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    
    IEnumerator MoverPlatFinal()
    {
        float posX = animPlataformaFinal.transform.position.x;
        float posY = animPlataformaFinal.transform.position.y;
        for (int i = 0; i < 26; i++)
        {
            animPlataformaFinal.transform.position = (new Vector3(posX, posY += 0.18f));
            yield return new WaitForSeconds(0.000001f);
        }
        yield break;
    }
    
    public void DisableTutoFaster()
    {
        tutorialScreenIsEnabled = true;
        GameObject.FindGameObjectWithTag("Tutorial").SetActive(false);
        SaltoConejo.instance.JumpSecondTimeInvokation();
    }
    public void DisableTutoSlower()
    {
        tutorialScreenIsEnabled = true;
        GameObject.FindGameObjectWithTag("Tutorial").SetActive(false);
        SaltoConejo.instance.JumpFirstTimeInvokation();
    }

    void OnApplicationPause()
    {
        if(gameOver == false && tutorialScreenIsEnabled == true)pause = true;
    }
}
