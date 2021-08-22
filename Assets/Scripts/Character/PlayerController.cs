using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller; //Controller için referans
    public Transform cam;

    public float speed = 0f; //Hýz için deðiþken
    public float maxSpeed = 10f;
    public float acceleration = 50f;

    public float turnSmoothTime = 0.1f; // frame baþýna dönüþ için 

    float turnSmoothVelocity; // þu anki smooth velocity nin tutulduðu deðiþken

    float gravity = -9.81f;
    Vector3 velocity = Vector3.zero;
    Vector3 moveDir;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //x de ve z de harek için + 2 sine de basýnca hýzlarý birleþmesin diye normalized eklendi

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //Atan2 parentez arasýnda verilen iki axes arasýndaki açýyý veren ve 0 dan baþlayan bir deðer / Rad2Deg Radyan ý dereceye çeviren fonksiyon / + cam.eulerAngles.y kameranýn y de yaptýðý harteketi ekliyoruz

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // Þu an ki angle==transform.eulerAngles.y / turnSmoothVelocity==þu anki smooth velocity 

            transform.rotation = Quaternion.Euler(0f, angle, 0f); // Hangi eksende döneceði bilgisi

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // rotation into direction kamera için 
            controller.Move(moveDir.normalized * speed * Time.deltaTime); //Yön bilgisi

            
        }
        else if(direction.magnitude <= 0f)
        {
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            speed += acceleration * Time.deltaTime;
            if (speed > 15f)
            {
                acceleration = 0;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            acceleration = 5;
            if(speed > 0)
            {
                speed -= (acceleration * Time.deltaTime) * 2;
            }
            else
            {
                speed -= acceleration * Time.deltaTime;
            }
        }
        else
        {
            acceleration = 5;
            if (speed > 0)
                speed -= (acceleration * Time.deltaTime) / 2;
            if(speed < 0)
                speed += (acceleration * Time.deltaTime) / 2;
            if (speed > 0 && speed < 1 || speed > 0 && speed < -1)
                speed = 0;
        }
            
    }

    public void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            Debug.Log(isGrounded);
        }

        Debug.Log(velocity);
        

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}