using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane_controller : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;

    private Vector3 direction;

    private float Horizantol_input;
    private float Vertical_input;

    private Vector3 velocity;
    private Vector3 acceleration = new Vector3(0f, 9.85f, 0f); //9.8 is for counter gravity

    private Vector3 rot; //rotation
    public void Update()
    {
        get_input();
    }
    public void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        increase_velocity();
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        direction = new Vector3(0f, velocity.y, 0f) * Time.fixedDeltaTime;
    }
    public void get_input()
    {
        Horizantol_input = Input.GetAxis("Horizontal");
        Vertical_input = Input.GetAxis("Vertical");
    }
    public void increase_velocity()
    {
        velocity += acceleration;
    }
    public void rotate_plane()
    {
        Quaternion delta_rotation = Quaternion.Euler(rot * Time.fixedDeltaTime);
        if(Horizantol_input == 1)
        {

        }
    }
}
