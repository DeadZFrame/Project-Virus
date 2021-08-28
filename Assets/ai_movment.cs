using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_movment : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 100000;
    public float speed = 5;

    public void FixedUpdate()
    {
        move();
    }
    public void move()
    {
        rb.MovePosition(rb.position + Vector3.right * Time.fixedDeltaTime);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("yes");
            //player_rb.AddForce(new Vector3(1000000, 1000000, 1000000));
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-force, 0, 0));
        }
    }
    
}
