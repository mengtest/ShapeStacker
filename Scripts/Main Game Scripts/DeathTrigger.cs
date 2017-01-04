using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class DeathTrigger : MonoBehaviour {

    public bool hasLost = false;

	void OnTriggerEnter2D()
    {
        //game over
        hasLost = true;
    }

    void OnGUI()
    {
        if (hasLost)
        {
            GUI.color = Color.black;
            GUI.skin.label.fontSize = 60;
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 1000, 200), "Game Over!");

            GUIStyle buttonText = new GUIStyle("button");
            buttonText.fontSize = 60;

            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 200, 250, 90), "Restart?", buttonText))
            {
                SceneManager.LoadScene("physics game"); //reload the level
            }
        }
    }
}
