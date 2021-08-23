using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_player : MonoBehaviour
{
    public LayerMask layerMask;

    public float radius = 5f;

    private void Update()
    {
        check();
    }
    void check()
    {
        if(Physics.CheckSphere(transform.position, radius, layerMask))
        {
            Debug.Log("yes");
            //activate the child object
            GameObject child = gameObject.transform.GetChild(0).gameObject;
            child.SetActive(true);
        }
    }
}
