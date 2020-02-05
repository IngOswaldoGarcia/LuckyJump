using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour {

    public static CloudsMovement instance;

    public  Rigidbody2D rb2d;
    public static float cloudSpeed = -0.1f;

    void Awake()
    {
        CloudsMovement.instance = this;
        rb2d.GetComponent<Rigidbody2D>();
    }

    

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(rb2d.transform.position.x < -5.14f)
        {
            Destroy(gameObject, 0);
            RespawnClouds.instance.CreatorClouds();
            //rb2d.transform.position = new Vector2(5.16f, Random.Range(0.45f, 3.1f));
        }
        rb2d.velocity = new Vector2(cloudSpeed, 0);
    }
    public void IncreaseSpeed()
    {
        cloudSpeed -= 0.1f;
    }
    public void ResetSpeed()
    {
        cloudSpeed = -0.1f;
    }
}
