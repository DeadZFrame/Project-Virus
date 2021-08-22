using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller; //Controller i�in referans
    public Transform cam;

    public float speed = 6f; //H�z i�in de�i�ken

    public float turnSmoothTime = 0.1f; // frame ba��na d�n�� i�in 

    float turnSmoothVelocity; // �u anki smooth velocity nin tutuldu�u de�i�ken

    float gravity = -9.81f;
    Vector3 velocity = Vector3.zero;

    public Transform groundCheck;
    public float groundDistance;
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
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //x de ve z de harek i�in + 2 sine de bas�nca h�zlar� birle�mesin diye normalized eklendi

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //Atan2 parentez aras�nda verilen iki axes aras�ndaki a��y� veren ve 0 dan ba�layan bir de�er / Rad2Deg Radyan � dereceye �eviren fonksiyon / + cam.eulerAngles.y kameran�n y de yapt��� harteketi ekliyoruz

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // �u an ki angle==transform.eulerAngles.y / turnSmoothVelocity==�u anki smooth velocity 

            transform.rotation = Quaternion.Euler(0f, angle, 0f); // Hangi eksende d�nece�i bilgisi

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // rotation into direction kamera i�in 
            controller.Move(moveDir.normalized * speed * Time.deltaTime); //Y�n bilgisi
        }
    }

    public void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}