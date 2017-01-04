using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void Restart()
    {
        //reload the current scene
        GameObject gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
