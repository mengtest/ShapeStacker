using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
     public GameObject gameOverPanel;
     public Text gameOverText;


     public int playerScore;

    void Awake()
    {
        // gameOverText = GetComponentInChildren<Text>();
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
    }

    void FixedUpdate()
    {
        //check if the player has lost
        if (GameObject.Find("Boundary").GetComponent<DeathTrigger>().hasLost)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //player has lost - activate game over panel
        gameOverPanel.SetActive(true);

        playerScore = FindObjectOfType<ScoreManager>().score;  //get the player's current score

        gameOverText.text = "Your Score was:" + playerScore;  //show their score
    }

    public void LeaveGame()
    {
        //load the main menu
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        //reload the current scene
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
