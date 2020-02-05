using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallax : MonoBehaviour {

    public float velPinosFrontales = 0.03f;
    public float velPinosTraseros = 0.01f;
    public float velNubes = 0.005f;
    public float velNubesDel = 0.01F;
    public Renderer[] renderer;
    public static ScrollParallax instance;
    public float tiempoInicio = 0f;
    public float tiempoConcurrente = 0f;
    public bool menu = false;
    public float incremento = 0.15f;
    public float tiempo = 0;
        
    void Awake()
    {
        renderer[3].GetComponent<Renderer>();
        ScrollParallax.instance = this;
    }

	// Use this for initialization
	void Start () {
        
    }
	
    public void MovimientoFondo()
    {
        
    }

	void Update ()
    {    
            if (menu == true)
        {
            renderer[0].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velPinosFrontales, 0);
            renderer[1].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velPinosTraseros, 0);
            renderer[2].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velNubes, 0);
            renderer[3].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velNubesDel, 0);
        }
            else if (SaltoConejo.instance.conejoSalio == true)
            {
                renderer[0].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velPinosFrontales, 0);
                renderer[1].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velPinosTraseros, 0);
                renderer[2].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velNubes, 0);
                renderer[3].material.mainTextureOffset = new Vector2((tiempoConcurrente += incremento) * velNubesDel, 0);
            }
        }
    public void IncrementarVelFondo()
    {
        incremento += 0.15f;
        CloudsMovement.instance.IncreaseSpeed();
    }

    IEnumerator DecrementBackGroundVel()
    {
        for(int i = 0; i < 10; i++)
        {
            if (incremento == 0.15f) break;
            incremento -= 0.15f;
            yield return new WaitForSeconds(0.05f);

        }
    }
}
    

