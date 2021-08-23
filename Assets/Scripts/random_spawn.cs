using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_spawn : MonoBehaviour
{
    //objects to spawn
    public GameObject[] objects;
    //player
    public GameObject player;

    public Vector3 end_point;

    //for the horizantol distance between spawned object
    public int horizantal_width = 10;

    public Vector2 vertical_randomnes = new Vector2(1, 5);
    //the direction where to spawn the obstacles
    //public Vector3 spawn_direction = Vector3.right;

    private void Awake()
    {
        Genereate(player.transform.position, end_point, vertical_randomnes);
    }
    private void Genereate(Vector3 start_point, Vector3 end_point, Vector2 randomness)
    {
        //end point is to define where to end, randomness is for the random spawning for the forward axes
        //usage to define the direction where the spawning goes change the vector in the for loop
        int rand_vertical = Random.Range((int)randomness.x, (int)randomness.y);

        for (float i = start_point.x + rand_vertical; i < end_point.x; i += rand_vertical)
        {
            int rand_horizontal = Random.Range(-2, 3);
            rand_horizontal = rand_horizontal * horizantal_width;
            GameObject random_object = get_random_object();
            Instantiate(random_object, new Vector3(i, player.transform.position.y, player.transform.position.z + rand_horizontal), Quaternion.identity);
            rand_vertical = Random.Range((int)randomness.x, (int)randomness.y);
        }
    }

    private GameObject get_random_object()
    {
        int rand = Random.Range(0, objects.Length);
        return objects[rand];
    }
}
