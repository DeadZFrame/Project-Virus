using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage_scene : MonoBehaviour
{
    private void Update()
    {
        //if pressed r reste the level
        if(Input.GetKey("r"))
        {
            Debug.Log("yes");
        }
    }
}
