using UnityEngine;
using System.Collections;

public class ObjectCollision : MonoBehaviour
{

    public AudioClip clip;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 8)
        {
            //play sound each time a shape hits another
            GetComponent<AudioSource>().Play();
        }
    }




	// Use this for initialization
	void Start ()
    {
        GetComponent<AudioSource>().clip = clip;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
