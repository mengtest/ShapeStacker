using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int score = 0;

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.skin.label.fontSize = 65;
        GUI.Label(new Rect(0, 0, 1000, 200), "Score: " + score);        
    }
}
