using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory_event : MonoBehaviour
{
    public GameObject Particule_to_spawn;
    public void destroy_object()
    {
        GameObject destroy_object = check_parent(gameObject);
        Instantiate(Particule_to_spawn, destroy_object.transform.position, Quaternion.identity);
        Destroy(destroy_object);
    }

    GameObject check_parent(GameObject @object)
    {
        //cheks if the object has parent. if there is returns that game object
        if(@object.transform.parent == null)
        {
            return @object;
        }
        return check_parent(@object.transform.parent.gameObject);
    }
}
