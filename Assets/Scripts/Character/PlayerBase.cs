using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase: MonoBehaviour
{
    [System.NonSerialized]public static PlayerBase referance;
    public float health = 100;
    private float temp;

    private bool hit = false;

    private void Update()
    {
        OnHit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle"))
        {
            hit = true;
            temp = health - 20;
        }
    }

    public void OnHit()
    {
        if (hit)
        {
            health = Mathf.Lerp(health, health - 20, 0.05f);
            if(health <= temp)
            {
                hit = false;
            }
        }

    }
}