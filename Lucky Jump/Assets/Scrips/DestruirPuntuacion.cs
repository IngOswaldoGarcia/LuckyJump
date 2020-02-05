using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPuntuacion : MonoBehaviour {

    float tiempo = 0;



    // Use this for initialization
    void Start () {
        //
        //transform.SetSiblingIndex(11);
        Destroy(gameObject, 1);

	}
	
	// Update is called once per frame
	void Update () {

    }
}
