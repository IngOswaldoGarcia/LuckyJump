using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameState : MonoBehaviour {
    
    public static GameState gameEstate;
    public static GameState instence;
    public int maxScore = 0;
    public int deadsCounter = 0;
    public bool restartLevelState = false;

    private String fileRoute;
    

    public void Awake()
    {
        GameState.instence = this;

        //fileRoute = Application.persistentDataPath + "/data.dat"; 
        
        if (gameEstate == null)
        {
            gameEstate = this;
            DontDestroyOnLoad(gameObject);
        } else if(gameEstate != this)
        {
            Destroy(gameObject);
        }
        //OnMenu = true;
    }
    // Use this for initialization
	void Start () {
        //LoadDeadsCounter();
        
    }
	
	// Update is called once per frame
	public void Update () {
        
      
    }
    /*
    public void IncreaseDeadsCounter()
    {
        deadsCounter = ControladorJuego.instance.deadsCounter;
        SaveDeadsCounter();
    }



    public void LoadDeadsCounter()
    {
        if(File.Exists(fileRoute))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileRoute, FileMode.Open);

            DataToSave data = (DataToSave)bf.Deserialize(file);

            deadsCounter = data.deadsCounter;

            file.Close();
        }
        else
        {
            deadsCounter = 0;
        }
        
    }

    public void SaveDeadsCounter()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(fileRoute);

        DataToSave data = new DataToSave();
        data.deadsCounter = deadsCounter;

        bf.Serialize(file, data);

        file.Close();
    }*/

}
/*
[Serializable]
class DataToSave
{
    public int deadsCounter;

}*/