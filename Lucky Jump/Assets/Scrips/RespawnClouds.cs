using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnClouds : MonoBehaviour {

    public static RespawnClouds instance;
    public Rigidbody2D[] cloudsMovement;

    void Awake()
    {
        RespawnClouds.instance = this;
    }

    // Use this for initialization
    void Start () {
        Instantiate(cloudsMovement[Random.Range(1, 3)], new Vector2(-2.2f, Random.Range(0.45f, 3.1f)), Quaternion.identity);
        Instantiate(cloudsMovement[Random.Range(0, 4)], new Vector2(-0.2f, Random.Range(0.45f, 3.1f)), Quaternion.identity);
        Instantiate(cloudsMovement[Random.Range(2, 4)], new Vector2(1.5f, Random.Range(0.45f, 3.1f)), Quaternion.identity);
        Instantiate(cloudsMovement[Random.Range(0, 4)], new Vector2(3.5f, Random.Range(0.45f, 3.1f)), Quaternion.identity);
        Instantiate(cloudsMovement[Random.Range(0, 2)], new Vector2(-5.12f, Random.Range(0.45f, 3.1f)), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {


    }

    public void CreatorClouds()
    {
        Instantiate(cloudsMovement[Random.Range(0, 4)], new Vector2(5.16f, Random.Range(0.45f, 3.1f)), Quaternion.identity);
    }
}
