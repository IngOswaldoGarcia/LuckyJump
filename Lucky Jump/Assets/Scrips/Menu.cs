using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class Menu : MonoBehaviour {

    Animator Anim;
    public GameObject loadingScreen;

    void Awake() {
        
        Anim = GetComponent<Animator>();

    }

	void Start () {
		
	}

    public void BotonMenutoStats()
    {
        if (Social.localUser.authenticated)
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIlLGPi4cYEAIQAQ");
        }
        else
        {
            Social.localUser.Authenticate((bool success) => { });
        }
        
    }

    public void ContinueGame()
    {
        ControladorJuego.instance.pause = false;
        SoundSystem.instance.UnPauseGameMusic();
        ControladorJuego.instance.pauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        ControladorJuego.instance.pause = true;
        SoundSystem.instance.PauseGameMusic();
        SoundSystem.instance.PlaySoundPauseButton();
        ControladorJuego.instance.pauseButton.SetActive(false);
        
    }

    public void BotonMenuToMenuSalida()
    {
        Anim.SetTrigger("Menu_MenuSalida");
        //SoundSystem.instance.PlaySoundClicButton();
    }
    public void BotonMenuToMenuPersonajes()
    {
        Anim.SetTrigger("Menu_MenuPersonaje");
    }

    public void BotonMenuSalidaToMenuPrincipal()
    {
        Anim.SetTrigger("MenuSalida_Menu");
        
        // SoundSystem.instance.PlaySoundClicButton();
    }

    public void BotonMenuPersonajesToMenuPrincipal()
    {
        Anim.SetTrigger("MenuPersonaje_Menu");
    }

    public void BotonScenaJuegoToMenu()
    {
        ControladorJuego.instance.pause = false; 
        SoundSystem.instance.StopGamePlayMusic();
        ControladorJuego.instance.loadingScreenGameScene.SetActive(true);
        SceneManager.LoadScene(0);
    }

	public void BotonTutorialToMenu()
	{
		Anim.SetTrigger ("Tutorial_Menu");
	}
	public void BotonMenuToTutorial()
	{
		Anim.SetTrigger ("Menu_Tutorial");
	}

	public void BotonTutorialToSceneJuego(){
        loadingScreen.SetActive(true);
        MenuChecker.instance.StopPrincipalScreenMusic();
        SceneManager.LoadScene(1);
        
    }

    public void SalirDelJuego()
    {
        SoundSystem.instance.PlaySoundClicButton();
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
