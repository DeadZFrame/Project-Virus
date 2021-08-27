using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_movment : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5;

    public void FixedUpdate()
    {
        move();
    }
    public void move()
    {
        rb.MovePosition(rb.position + Vector3.right * Time.fixedDeltaTime);
    }
}
