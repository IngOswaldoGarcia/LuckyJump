using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "platCommon") {
            SaltoConejo.instance.HittingPlatform();
        }
    }
}
