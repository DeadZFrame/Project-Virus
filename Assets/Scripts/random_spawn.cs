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
    public float horizantal_width = 10;

    public float object_lengt;

    public Vector2 vertical_randomnes = new Vector2(1, 5);

    private List<GameObject> generatable_roads = new List<GameObject>();
    //private List<GameObject> object_to_add = new List<GameObject>();
    private int choosed_index = -1;
    private Vector3 car_start_pos;
    //the direction where to spawn the obstacles
    //public Vector3 spawn_direction = Vector3.right;

    Scene scene;

    private void Awake()
    {
        /*for (int i = 0; i < roads.Length; i++)
        {
            generatable_roads.Add(roads[i]);
        }*/
        car_start_pos = player.transform.position;
        scene = SceneManager.GetActiveScene();
        if(scene.name == "car_scene" || scene.name == "2012-Level1")
        {
            Genereate_desaster(start_point, end_point, vertical_randomnes);
            Generate_road(start_point, end_point, object_lengt);
        }
    }

    private void Start()
    {
        if (scene.name.Equals("deneme"))
        {
            SpawnTornado();
        }
    }

    private void Genereate_desaster(Vector3 start_point, Vector3 end_point, Vector2 randomness)
    {
        //end point is to define where to end, randomness is for the random spawning for the forward axes
        //usage to define the direction where the spawning goes change the vector in the for loop
        int rand_vertical = Random.Range((int)randomness.x, (int)randomness.y);

        for (float i = start_point.x + rand_vertical; i < end_point.x; i += rand_vertical)
        {
            if(i > car_start_pos.x + 1 || i < car_start_pos.x - 1)
            {

                int rand_horizontal = Random.Range(-2, 3);
                float new_value = rand_horizontal * horizantal_width;
                GameObject random_object = get_random_object(objects);
                Instantiate(random_object, new Vector3(i, random_object.transform.position.y, start_point.z + new_value), Quaternion.identity);
                rand_vertical = Random.Range((int)randomness.x, (int)randomness.y);
            }
        }
    }
    private void Generate_road(Vector3 start_point, Vector3 end_point, float length)
    {
        for (float i = start_point.x, z = 0; i < end_point.x; i += length, z++)
        {
            //it keep from to instantiate two times the same object
            //Debug.Log(generatable_roads.Count);
           
            GameObject random_object = getrandom_road();
            GameObject instantiate_object = Instantiate(random_object, new Vector3(i, start_point.y, start_point.z), Quaternion.identity);
            //add_removed_object();
            //generatable_roads.Remove(object_to_add[0]);
            //instantiate_object.SetActive(false);
        }
    }

    private GameObject get_random_object(GameObject[] Objects)
    {
        int rand = Random.Range(0, Objects.Length);
        return Objects[rand];
    }

    private GameObject getrandom_road()
    {
        if(roads.Length > 1)
        {
            int rand = Random.Range(0, roads.Length);
            while (choosed_index == rand)
            {
                rand = Random.Range(0, roads.Length);
            }
            choosed_index = rand;
            return roads[rand];
        }
        else
        {
            return roads[0];
        }
    }
    /*private void add_removed_object()
    {
        for (int i = 0; i < generatable_roads.Count; i ++)
        {
            //Debug.Log(generatable_roads[i]);
            if(object_to_add[0] == generatable_roads[i])
            {
                return;
            }
        }
        
        if(object_to_add != null)
        {
            Debug.Log("yes");
            generatable_roads.Add(object_to_add[0]);
            object_to_add.Remove(object_to_add[0]);
            object_to_add[0] = object_to_add[1];
        }
    }*/

    public int tornadoSpawnCount, distanceIndex;
    private int spawned = 0;
    public void SpawnTornado()
    {
        float randomX = 0;
        float randomZ = 0;
        float height = 500;

        while (spawned <= tornadoSpawnCount)
        {
            Vector3 position = new Vector3(randomX, height, randomZ);

            Instantiate(tornado, position, Quaternion.identity);
            randomX = Random.Range(-distanceIndex, distanceIndex) + transform.position.x;
            randomZ = Random.Range(-distanceIndex, distanceIndex) + transform.position.z;
            spawned++;
        }
    }
}
