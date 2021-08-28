using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Contains player info
public class PlayerBase: MonoBehaviour
{
    CameraShake cameraShake;
    public GameObject explosion_particule;

    [System.NonSerialized] public static PlayerBase referance;
    public static float health = 100;
    private float temp;

    private bool hit = false;
    private bool particule_created = false;
    private void Awake()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        health = 100;
    }

    private void Update()
    {
        OnHit();

        if(health <= 0)
        {

            if (particule_created)
            {
                Instantiate(explosion_particule, gameObject.transform);
                particule_created = false;
            }
            StartCoroutine(load_scene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle")) //Player takes damage when entering to the obstacle trigger
        {
            particule_created = true;
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
    IEnumerator load_scene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}