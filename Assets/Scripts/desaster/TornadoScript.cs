using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TornadoScript : MonoBehaviour
{
    Vector3 chaosPos;

    private float x, z;
    private float randomX, randomZ;
    private bool moving = false;

    public float turnSpeed;
    public float pull_force = 10000;
    private TextMeshProUGUI dead_text;
    private void Update()
    {
        PositionRandomizer();
    }

    public void PositionRandomizer()
    {
        while (!moving)
        {
            randomX = Random.Range(-20, 20);
            randomZ = Random.Range(-20, 20);
            moving = true;
            StartCoroutine(SetBoolFalse(Random.Range(3f, 11f)));
        }

        if (x < randomX || z < randomZ)
        {
            if (x < randomZ)
                x += turnSpeed * Time.deltaTime;
            else if (z < randomZ)
                z += turnSpeed * Time.deltaTime;
        }
        if (x > randomX || z > randomZ)
        {
            if (x > randomZ)
                x -= turnSpeed * Time.deltaTime;
            else if (z > randomZ)
                z -= turnSpeed * Time.deltaTime;
        }

        float smoothTransitionX = Mathf.Lerp(transform.position.x, transform.position.x + x, 0.02f);
        float smoothTransiitionZ = Mathf.Lerp(transform.position.z, transform.position.z + z, 0.02f);

        chaosPos = new Vector3(smoothTransitionX, 1000, smoothTransiitionZ);

        transform.position = chaosPos;
    }

    IEnumerator SetBoolFalse(float time)
    {
        yield return new WaitForSeconds(time);
        moving = false;
    }

    //tornado hit
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject cam = GameObject.Find("Main Camera");
            GameObject plane = GameObject.Find("airplane");
            //GameObject follow_object = GameObject.Find("camera_follow_when_crashed");
            Rigidbody rb = plane.GetComponent<Rigidbody>();
            //deparent camera
            cam.transform.parent = null;
            //add force to the plane through tornado
            Vector3 direction = gameObject.transform.position - plane.transform.position;
            direction.y = 0;
            cam.transform.LookAt(plane.transform);
            direction = direction.normalized;
            rb.AddForce(direction * pull_force);
            dead_text = GameObject.Find("you died").GetComponent<TextMeshProUGUI>();
            dead_text.enabled = true;
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            yield return null;
        }
    }
}
