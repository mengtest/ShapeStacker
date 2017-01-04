using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour {

    public float targetY = 0;


    


    void Update()
    {
        //move camera upwards after a threshold is met
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(transform.position.y, targetY, 0.1f);
        transform.position = pos;
    }
}
