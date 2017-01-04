using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreTxt;
    public Text highScoreTxt;

    public int score = 0;


    void Awake()
    {   
        scoreTxt = GetComponent<Text>();
    }

    void AddScore()
    {
        score++;
        scoreTxt.text = "Score:" + score;
    }

  /*  void OnGUI()
    {
        GUI.color = Color.black;
        GUI.skin.label.fontSize = 65;
        GUI.Label(new Rect(0, 0, 1000, 200), "Score: " + score);        
    }*/
}
