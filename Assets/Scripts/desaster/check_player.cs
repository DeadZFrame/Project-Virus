using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_player : MonoBehaviour
{
    public LayerMask layerMask;

    public GameObject object_to_set_active;

    public float radius = 5f;

    private void Update()
    {
        check(object_to_set_active);
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
            Debug.Log("yes");
            object_to_set_active.SetActive(false);
        }
    }
}
