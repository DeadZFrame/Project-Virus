using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_direction : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public static Vector3 direction;

    public void Update()
    {
        direction = (pos2.position - pos1.position).normalized;
    }
}
