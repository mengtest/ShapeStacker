using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D()
    {
       // Vector3 camPos = Camera.main.transform.position;

        if(Camera.main.transform.position.y < transform.position.y)
        {

            Camera.main.GetComponent<CamMove>().targetY = transform.position.y;
        }
    }
	
}
