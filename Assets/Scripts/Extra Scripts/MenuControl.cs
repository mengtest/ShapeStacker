using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;

    Vector3 startPos;


	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //move background image to the left indefinitely.
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, tileSize);  //change pos to never go above tilesize
        transform.position = startPos + new Vector3(1,0,0) * newPos;
	}
}
