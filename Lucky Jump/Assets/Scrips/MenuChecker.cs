using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChecker : MonoBehaviour {

    public bool OnMenu = true;

    public static MenuChecker instance;

    public AudioSource principalScreenMusic;

    void Awake()
    {
        MenuChecker.instance = this;
        
    }

	// Use this for initialization
	void Start () {
        if (OnMenu == true) PlayerPrefs.SetInt("OnMenuTrue",0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StopPrincipalScreenMusic()
    {
        principalScreenMusic.Stop();
    }
}
