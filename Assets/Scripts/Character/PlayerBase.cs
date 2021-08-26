using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains player info
public class PlayerBase: MonoBehaviour
{
    [System.NonSerialized] public static PlayerBase referance;
    public static float health = 100;
    private float temp;

    private bool hit = false;

    private void Update()
    {

        OnHit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle")) //Player takes damage when entering to the obstacle trigger
        {
            health -= 20;
            Debug.Log("Çat!");
            hit = true;
            temp = health - 20;
        }
    }

    public void OnHit() //Method for health bar's smooth decrease effect
    {
        if (hit)
        {
            health = Mathf.Lerp(health, health - 20, 0.05f); //Math function for a value's slow transition to another value
            if (health <= temp)
            {
                hit = false;
            }
        }

    }
}