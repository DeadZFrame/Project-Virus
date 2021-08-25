using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
