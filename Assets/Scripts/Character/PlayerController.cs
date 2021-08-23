using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller; //Controller i�in referans
    public Transform cam;

    public float speed = 0f; //H�z i�in de�i�ken
    public float maxSpeed = 10f, minSpeed;
    public float acceleration = 50f;
    private float rotation = 0;
    private float VRotate = 0;

    public float turnSmoothTime = 10f; // frame ba��na d�n�� i�in 

    float turnSmoothVelocity; // �u anki smooth velocity nin tutuldu�u de�i�ken

    float gravity = -9.81f;
    Vector3 velocity = Vector3.zero;
    Vector3 moveDir, direction, steer;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Gravity();
    }

    public void Movement()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //x de ve z de harek i�in + 2 sine de bas�nca h�zlar� birle�mesin diye normalized eklendi

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //Atan2 parentez aras�nda verilen iki axes aras�ndaki a��y� veren ve 0 dan ba�layan bir de�er / Rad2Deg Radyan � dereceye �eviren fonksiyon / + cam.eulerAngles.y kameran�n y de yapt��� harteketi ekliyoruz

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // �u an ki angle==transform.eulerAngles.y / turnSmoothVelocity==�u anki smooth velocity 

            //transform.rotation = Quaternion.Euler(0f, angle, 0f); // Hangi eksende d�nece�i bilgisi

            //moveDir = Quaternion.Euler(0f, rotation, 0f) * Vector3.forward; // rotation into direction kamera i�in 
            transform.rotation = Quaternion.Euler(0, rotation, 0);
            controller.Move(direction.normalized * speed * Time.deltaTime); //Y�n bilgisi  
        }
        else if(direction.magnitude <= 0f)
        {
            controller.Move(direction.normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = new Vector3(1, 0, 0).normalized;
            speed += acceleration * Time.deltaTime;
            if (speed > maxSpeed)
            {
                acceleration = 0;
            }
            else
            {
                acceleration = 5;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if(speed > 0)
            {
                speed -= (acceleration * Time.deltaTime) * 2;
            }
            else
            {
                speed -= acceleration * Time.deltaTime;
                direction = new Vector3(1, 0, 0).normalized;
                if (speed < minSpeed)
                {
                    acceleration = 0;
                }
                else
                {
                    acceleration = 5;
                }
            }
        }
        else
        {
            acceleration = 5;
            if (speed > 0)
                speed -= (acceleration * Time.deltaTime) / 2;
            if(speed < 0)
                speed += (acceleration * Time.deltaTime) / 2;
            if (speed > 0 && speed < 0.5f || speed > 0 && speed < -0.5f)
                speed = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if(VRotate <= 1f)
                VRotate += 0.2f * Time.deltaTime;
            else VRotate = 0;

            if (rotation > -13)
                rotation -= 50f * Time.deltaTime;
            steer = new Vector3(0, 0, VRotate);

            controller.Move(steer.normalized * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (VRotate <= 1f)
                VRotate -= 0.2f * Time.deltaTime;
            else VRotate = 0;

            if (rotation < 13)
                rotation += 50f * Time.deltaTime;
            steer = new Vector3(0, 0, VRotate);

            controller.Move(steer.normalized * speed * Time.deltaTime);
        }
        else
        {
            rotation = Mathf.Lerp(rotation, 0 , 0.08f);
            VRotate = 0;
        }
    }

    public void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Debug.Log(velocity);
        

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}