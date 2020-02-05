using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MaxScore : MonoBehaviour {

    public Text maxScore;
    public Shadow shadow;

    private void Awake()
    {
        PlayGamesPlatform.Activate();
    }

    // Use this for initialization
    void Start () {

        ((PlayGamesPlatform)Social.Active).Authenticate((bool succes) => { }, true);

        maxScore.text = PlayerPrefs.GetInt("MaxScore").ToString();
        if(PlayerPrefs.GetInt("MaxScore") >= 1000 && PlayerPrefs.GetInt("MaxScore") < 10000)
        {
            maxScore.fontSize = 68;
            shadow.effectDistance = new Vector2(3.5f, -4f);
        }
        else if(PlayerPrefs.GetInt("MaxScore") >= 10000 && PlayerPrefs.GetInt("MaxScore") < 100000)
        {
            maxScore.fontSize = 53;
            shadow.effectDistance = new Vector2(3, -3.5f);
        }
        else if (PlayerPrefs.GetInt("MaxScore") >= 100000 && PlayerPrefs.GetInt("MaxScore") < 1000000)
        {
            maxScore.fontSize = 44;
            shadow.effectDistance = new Vector2(2.5f, -3f);
        }
        else if (PlayerPrefs.GetInt("MaxScore") >= 1000000 && PlayerPrefs.GetInt("MaxScore") < 10000000)
        {
            maxScore.fontSize = 40;
            shadow.effectDistance = new Vector2(2,-2.5f);
        }
        else if (PlayerPrefs.GetInt("MaxScore") >= 10000000 && PlayerPrefs.GetInt("MaxScore") < 100000000)
        {
            maxScore.fontSize = 34;
            shadow.effectDistance = new Vector2(1.7f, -2.2f);
        }
        else if (PlayerPrefs.GetInt("MaxScore") >= 100000000 )
        {
            maxScore.fontSize = 30;
            shadow.effectDistance = new Vector2(1.3f, -1.8f);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
