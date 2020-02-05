using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaCatapultaDerecha : MonoBehaviour {

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && SaltoConejo.instance.isDead == false)
        {
            SaltoConejo.instance.rb2d.velocity = Vector2.down * 100;
            ChoqueConPiso.instance.SonidoGolpe();
            //SaltoConejo.instance.isDead = true;
            Debug.Log("Paso por aqui");
        }
    }
}
