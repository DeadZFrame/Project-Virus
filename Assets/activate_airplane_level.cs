using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_airplane_level : MonoBehaviour
{
    //used in the airplane explication text
    GameObject manager;
    private void Awake()
    {
        manager = GameObject.Find("scene_manager");
    }
    public void activate_desaster()
    {
        manager.GetComponent<spawn_meteor>().enabled = true;
        manager.GetComponent<random_spawn>().enabled = true;
    }
}
