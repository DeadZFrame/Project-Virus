using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase: MonoBehaviour
{
    [System.NonSerialized]public static PlayerBase referance;
    public float health = 100;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Thunder"))
        {
            health -= 20;
            Debug.Log("çat!");
        }
    }
}