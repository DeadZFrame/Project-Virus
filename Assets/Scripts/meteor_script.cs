using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_script : MonoBehaviour
{
    private GameObject particule_to_create;
    public GameObject cam; //it is to avoid the camera's destruction

    private void Awake()
    {
        cam = GameObject.Find("Main Camera");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ground")
        {
            Destroy(gameObject);
        }
        else if(collision.collider.tag == "Player")
        {
            //create_particules();
            cam.transform.parent = null;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    public void create_particules()
    {
        Instantiate(particule_to_create, transform.position, Quaternion.identity);
    }
}
