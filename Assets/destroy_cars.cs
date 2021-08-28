using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_cars : MonoBehaviour
{
    private GameObject to_destroy_object;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            to_destroy_object = collision.gameObject.transform.parent.gameObject;
            Debug.Log("yes");
            Destroy(to_destroy_object);
        }
    }
}
