using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void LeaveGame()
    {
        //load the main menu
        SceneManager.LoadScene(0);
    }

}
