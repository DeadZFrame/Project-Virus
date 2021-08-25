using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class random_spawn : MonoBehaviour
{
    //objects to spawn
    public GameObject[] objects;
    public GameObject tornado;
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
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("CarRush")) //String is temporary
        {
            Genereate(player.transform.position, end_point, vertical_randomnes);
        }
    }

    private void Start()
    {
        SpawnTornado();
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
            Instantiate(random_object, new Vector3(i, random_object.transform.position.y, player.transform.position.z + rand_horizontal), Quaternion.identity);
            rand_vertical = Random.Range((int)randomness.x, (int)randomness.y);
        }
    }

    private GameObject get_random_object()
    {
        int rand = Random.Range(0, objects.Length);
        return objects[rand];
    }

    public int tornadoSpawnCount, distanceIndex;
    private int spawned = 0;
    public void SpawnTornado()
    {
        float randomX = 0;
        float randomZ = 0;

        while (spawned <= tornadoSpawnCount)
        {
            Vector3 position = new Vector3(randomX, 100, randomZ);
            Instantiate(tornado, position, Quaternion.identity);
            randomX = Random.Range(-distanceIndex, distanceIndex) + tornado.transform.position.x;
            randomZ = Random.Range(-distanceIndex, distanceIndex) + tornado.transform.position.z;
            spawned++;
        }
    }
}
