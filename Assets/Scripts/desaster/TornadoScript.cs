using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    Vector3 chaosPos;

    private float x, z;
    private float randomX, randomZ;
    private bool moving = false;

    public float turnSpeed;

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

        chaosPos = new Vector3(smoothTransitionX, 20, smoothTransiitionZ);

        transform.position = chaosPos;
    }

    IEnumerator SetBoolFalse(float time)
    {
        yield return new WaitForSeconds(time);
        moving = false;
    }
}
