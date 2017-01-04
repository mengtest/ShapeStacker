using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathTrigger : MonoBehaviour {

    public bool hasLost = false;


    void OnTriggerEnter2D()
    {
        //game over
        hasLost = true;
        
    }

}
