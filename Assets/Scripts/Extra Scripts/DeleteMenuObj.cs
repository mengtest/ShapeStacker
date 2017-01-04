using UnityEngine;
using System.Collections;

public class DeleteMenuObj : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        //delete obj
        Destroy(coll.gameObject);
    }
    
}
