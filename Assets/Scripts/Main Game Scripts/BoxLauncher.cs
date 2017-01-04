using UnityEngine;
using System.Collections;

public class BoxLauncher : MonoBehaviour {

    public GameObject[] boxPrefabs;
    public GameObject scoring;

    public float fireVel = 10f;
    public float fireDelay = 3f;
    public float nextFire = 1f;

    void Start()
    {
        scoring = GameObject.Find("ScoreText");
    }



    //physics calcs
	void FixedUpdate ()
    {
        if (FindObjectOfType<DeathTrigger>().hasLost)
        {
            //if user has lost,  do nothing
            return;
        }
        nextFire -= Time.deltaTime;
        
        if(nextFire <= 0)
        {
            //spawn new object
            nextFire = fireDelay;

            //spawn an object randomly from the list of gameObjects
            GameObject box = (GameObject)Instantiate(boxPrefabs[Random.Range(0, boxPrefabs.Length)], 
                transform.position, transform.rotation);

            //set the velocity of the object so it reaches the platform
            box.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, fireVel);

            scoring.SendMessage("AddScore", SendMessageOptions.DontRequireReceiver); //every new shape = score + 1

        }    
	}
}
