using UnityEngine;
using System.Collections;

public class InitialVelocity : MonoBehaviour {

    public Vector3 initVel;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = initVel;
	}
	

}
