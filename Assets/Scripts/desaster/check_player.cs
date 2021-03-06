using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class check_player : MonoBehaviour
{
    public LayerMask layerMask;

    public GameObject object_to_set_active;

    public float radius = 5f;

    private Rigidbody moto_rb;
    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "2012-Level1")
        {
            moto_rb = GameObject.Find("Motocycle 1").GetComponent<Rigidbody>();
        }
        else if(scene.name == "car_scene")
        {
            moto_rb = GameObject.Find("NissanR35").GetComponent<Rigidbody>();
        }
    }
    private void Update()
    {
        check(object_to_set_active);
        //if the object is a thunder object
        if(object_to_set_active.name == "identificier gfx")
        {
            proprtion_radius_to_car_speed();
        }
        
    }

    void check(GameObject object_to_set_active)
    {
        if(Physics.CheckSphere(transform.position, radius, layerMask))
        {
            //activate the child object
            object_to_set_active.SetActive(true);
        }
        else if(gameObject.tag == "ground")
        {
            object_to_set_active.SetActive(false);
        }
    }
    void proprtion_radius_to_car_speed()
    {
        radius = moto_rb.velocity.x * 2;
    }
}
