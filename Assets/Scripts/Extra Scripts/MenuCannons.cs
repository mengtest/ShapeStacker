using UnityEngine;
using System.Collections;

public class MenuCannons : MonoBehaviour {

    public GameObject[] boxPrefabs;

    public float fireVel = 10f;
    public float fireDelay = 3f;
    public float nextFire = 1f;

    //physics calcs
    void FixedUpdate()
    {
        
        nextFire -= Time.deltaTime;

        if (nextFire <= 0)
        {
            //spawn new object
            nextFire = fireDelay;

            //spawn an object randomly from the list of gameObjects
            GameObject box = (GameObject)Instantiate(boxPrefabs[Random.Range(0, boxPrefabs.Length)],
                transform.position, transform.rotation);

            //set the velocity of the object so it reaches the platform
            box.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, fireVel);

          //  FindObjectOfType<ScoreManager>().score++; //every new shape = score + 1

        }
    }
}
