using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_meteor : MonoBehaviour
{
    //get the map's size
    public GameObject meteor;
    public Vector2 width_height = new Vector2(10f, 10f);
    public float y_spawn_pos = 100;
    public float wait_second = 1;
    public int randomness_intensity = 1; //

    private Vector2 random_x_y;
    private Vector3 spawn_point;

    private float current_time = 0;

    private void Awake()
    {
        spawn_point.y = y_spawn_pos;
    }

    private void Update()
    {
        current_time += Time.deltaTime;
        if(current_time > wait_second)
        {
            StartCoroutine(spawn_at_random_pos());
            current_time = 0;
        }
    }

    IEnumerator spawn_at_random_pos()
    {
        for(int i = 1; i <= randomness_intensity; i ++)
        {
            yield return new WaitForSeconds(wait_second / randomness_intensity);
            Debug.Log(i);
            spawn_point.x = Random.Range(-width_height.x, width_height.x);
            spawn_point.z = Random.Range(-width_height.y, width_height.y);
            Instantiate(meteor, spawn_point, Quaternion.identity);
            yield return new WaitForSeconds(wait_second/randomness_intensity);
        }
    }
}
