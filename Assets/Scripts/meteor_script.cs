using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meteor_script : MonoBehaviour
{
    public GameObject particule_to_create;
    private GameObject cam; //it is to avoid the camera's destruction
    private Transform airplane;

    private void Awake()
    {
        cam = GameObject.Find("Main Camera");
    }
    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            create_particules();
            yield return new WaitForSeconds(1f);
            MeshRenderer airplane_gfx = GameObject.Find("Jet").GetComponent<MeshRenderer>();
            airplane_gfx.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
    public void create_particules()
    {
        airplane = GameObject.Find("Jet").GetComponent<Transform>();
        Instantiate(particule_to_create, airplane);
    }
}
