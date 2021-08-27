using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains player info
public class PlayerBase: MonoBehaviour
{
    CameraShake cameraShake;

    [System.NonSerialized] public static PlayerBase referance;
    public static float health = 100;
    private float temp;

    private bool hit = false;   

    private void Awake()
    {
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void Update()
    {
        OnHit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle")) //Player takes damage when entering to the obstacle trigger
        {
            hit = true;
            temp = health - 20;
            StartCoroutine(cameraShake.CamShake(20, 0.5f));
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