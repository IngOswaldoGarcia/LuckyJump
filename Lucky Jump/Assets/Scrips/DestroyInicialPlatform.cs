using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInicialPlatform : MonoBehaviour {

    public GameObject plataforma;

    private void Awake()
    {
        //plataforma = GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

           // Destroy(other.gameObject);
        plataforma.SetActive(false);

            Debug.Log("la plataforma se debio desactivar");
        
    }
}
