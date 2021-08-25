using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class random_spawn : MonoBehaviour
{
    //objects to spawn
    public GameObject[] objects;
    public GameObject[] roads;
    public GameObject tornado;
    //player
    public GameObject player;

    public Vector3 start_point;

    public Vector3 end_point;

    //for the horizantol distance between spawned object
    public int horizantal_width = 10;

    public float object_lengt;

    public Vector2 vertical_randomnes = new Vector2(1, 5);
    //the direction where to spawn the obstacles
    //public Vector3 spawn_direction = Vector3.right;

    Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("2012-Level1")) //String is temporary
        {
            Genereate_desaster(player.transform.position, end_point, vertical_randomnes);
            Generate_road(start_point, end_point, object_lengt);
        }
    }

    private void Start()
    {
        SpawnTornado();
    }

    private void Genereate_desaster(Vector3 start_point, Vector3 end_point, Vector2 randomness)
    {
        //end point is to define where to end, randomness is for the random spawning for the forward axes
        //usage to define the direction where the spawning goes change the vector in the for loop
        int rand_vertical = Random.Range((int)randomness.x, (int)randomness.y);

        for (float i = start_point.x + rand_vertical; i < end_point.x; i += rand_vertical)
        {
            int rand_horizontal = Random.Range(-2, 3);
            rand_horizontal = rand_horizontal * horizantal_width;
            GameObject random_object = get_random_object(objects);
            Instantiate(random_object, new Vector3(i, random_object.transform.position.y, player.transform.position.z + rand_horizontal), Quaternion.identity);
            rand_vertical = Random.Range((int)randomness.x, (int)randomness.y);
        }
    }
    private void Generate_road(Vector3 start_point, Vector3 end_point, float length)
    {
        for(float i = start_point.x; i < end_point.x; i += length)
        {
            GameObject random_object = get_random_object(roads);
            GameObject instantiate_object = Instantiate(random_object, new Vector3(i, start_point.y, start_point.z), Quaternion.identity);
            //instantiate_object.SetActive(false);
        }
    }

    private GameObject get_random_object(GameObject[] Objects)
    {
        int rand = Random.Range(0, Objects.Length);
        return Objects[rand];
    }

    public int tornadoSpawnCount, distanceIndex;
    private int spawned = 0;
    public void SpawnTornado()
    {
        float randomX = 0;
        float randomZ = 0;

        //while (spawned <= tornadoSpawnCount)
        {
            Vector3 position = new Vector3(randomX, 100, randomZ);
            if(scene.name.Equals("deneme") || scene.name.Equals("MotorCycleExample"))
            {
                Instantiate(tornado, position, Quaternion.identity);
                randomX = Random.Range(-distanceIndex, distanceIndex) + tornado.transform.position.x;
                randomZ = Random.Range(-distanceIndex, distanceIndex) + tornado.transform.position.z;
                spawned++;
            }
        }
    }
}
