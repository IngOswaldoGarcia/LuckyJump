using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour {

    private List<GameObject> models;
    //Default index model
    private int selectionIndex = 1;

	// Use this for initialization

	    void Start ()
    {
        models = new List<GameObject>();
        foreach(Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        models[selectionIndex].SetActive(true);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) Select(1);
    }

    public void Select(int index)
    {
        if(index == selectionIndex)
        {
            return;
        }
        if(index < 0 || index >= models.Count)
        {
            return;
        }
        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);

    }
	
	
}
