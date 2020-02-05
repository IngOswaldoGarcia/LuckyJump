using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosPlat : MonoBehaviour {

    public Text textoPuntosPorPlat;
    public long puntosPlat = 0;
    public static PuntosPlat instance;
    public Rigidbody2D rb2d;
    public Text puntosTexto;
    void Awake()
    {
        PuntosPlat.instance = this;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void ActualizarMecador()
    {
        puntosPlat = MovimientoFuncionPlatAltern.intance.puntosPorPlataforma;
        textoPuntosPorPlat.text = "+" + puntosPlat;
        if(MovimientoFuncionPlatAltern.instance.incrementoPuntos == 10 
            || MovimientoFuncionPlatAltern.instance.incrementoPuntos == 20 
            || MovimientoFuncionPlatAltern.instance.incrementoPuntos == 30 
            || MovimientoFuncionPlatAltern.instance.incrementoPuntos == 40 
            || MovimientoFuncionPlatAltern.instance.incrementoPuntos == 50
            || MovimientoFuncionPlatAltern.instance.incrementoPuntos == 60)
        {
            textoPuntosPorPlat.color = new Color32(255,70,70,0);
        }
        if(MovimientoFuncionPlatAltern.instance.incrementoPuntos == 70)
        {
            textoPuntosPorPlat.color = new Color32(0, 169, 41, 0);
        }

        if (MovimientoFuncionPlatAltern.instance.incrementoPuntos == 100)
        {
            textoPuntosPorPlat.color = new Color32(0, 128, 255, 0);
        }
        /*   if(puntosPlat >= 10) textoPuntosPorPlat.fontSize = 17;
           if (puntosPlat >= 100) textoPuntosPorPlat.fontSize = 12;
           */
    }
}
