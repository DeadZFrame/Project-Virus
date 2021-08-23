using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_particule : MonoBehaviour
{
    public float dest_time = 1;
    private void Awake()
    {
        StartCoroutine(destroy_particules(dest_time));
    }

    IEnumerator destroy_particules(float dest_time)
    {
        yield return new WaitForSeconds(dest_time);
        Destroy(gameObject);
    }
}
