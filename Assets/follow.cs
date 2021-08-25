using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform object_to_follow;

    private void Awake()
    {
        transform.position = object_to_follow.position;
    }
    public void Update()
    {
        transform.position = object_to_follow.position;
    }

}
