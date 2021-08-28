using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_airplane_level : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            finish_the_level();
        }
    }
    public void finish_the_level()
    {
        Debug.Log("level_finished");
    }
}
