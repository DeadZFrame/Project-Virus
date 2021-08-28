using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class plane_controller : MonoBehaviour
{
    public Rigidbody rb; //that is for position
    public Transform rotation_referance; //that is for grafix
    public float speed = 5f;
    public float rotation_speed = 5f;
    public float max_speed = 5000;
    public float r_s = 10;
    private TextMeshProUGUI border_text;

    private Vector3 direction;

    private float Horizantol_input;
    private float Vertical_input;

    private Vector3 velocity = new Vector3(100f, 0f, 0f);
    private Vector3 acceleration = new Vector3(0f, 0f, 0f); //9.8 is for counter gravity
    private Vector3 tmp_acceleration;
    private float acceleration_max = 1000;

    private Vector3 rot; //rotation
    private Vector3 Global_rotation;

    //checks if the plane is in the area
    public static bool in_area = true;

    private Vector3 passed_rotation;
    private void Awake()
    {
        tmp_acceleration = acceleration;
    }
    public void Update()
    {
        get_input();
    }
    public void FixedUpdate()
    {
        //Debug.Log(velocity.x);
        //limit the velocity
        //increase_velocity();
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        Move();
    }
    public void Move()
    {
        increase_velocity();
        if (in_area)
        {
            rotate_and_move_plane();
            rotate_vertically();
        }
        else
        {
            passing_border();
        }
        
        direction = velocity * Time.fixedDeltaTime;
    }
    public void get_input()
    {
        Horizantol_input = Input.GetAxis("Horizontal");
        Vertical_input = Input.GetAxis("Vertical");
    }
    public void increase_velocity()
    {
        set_acceleration();

        //change velocity
        if (Mathf.Abs(velocity.x) < max_speed)
        {
            velocity.x += acceleration.x;
        }
        if(max_speed <= velocity.x && velocity.x <= max_speed + acceleration_max && acceleration.x < 0)
        {
            velocity.x += acceleration.x;
        }
        if(velocity.x <= -max_speed && velocity.x >= -max_speed - acceleration_max && acceleration.x > 0)
        {
            velocity.x += acceleration.x;
        }


        if (Mathf.Abs(velocity.z) < max_speed)
        {
            velocity.z += acceleration.z;
        }
        if (max_speed <= velocity.z && velocity.z <= max_speed + acceleration_max && acceleration.z < 0)
        {
            velocity.z += acceleration.z;
        }
        if (velocity.z <= -max_speed && velocity.z >= -max_speed - acceleration_max && acceleration.z > 0)
        {
            velocity.z += acceleration.z;
        }

        if (Mathf.Abs(velocity.y) < max_speed)
        {
            velocity.y += acceleration.y;
        }
        if (max_speed <= velocity.y && velocity.y <= max_speed + acceleration_max && acceleration.y < 0)
        {
            velocity.y += acceleration.y;
        }
        if (velocity.y <= -max_speed && velocity.y >= -max_speed - acceleration_max && acceleration.y > 0)
        {
            velocity.y += acceleration.y;
        }
    }
    public void set_acceleration()
    {
        //change acceleration
        //change the z value
        //float axe_y = get_y_value(transform.rotation.z);
        Vector3 axe = check_direction.direction;
        //Debug.Log(tmp_acceleration.y);
        acceleration.x += axe.x * 100000 * Time.fixedDeltaTime;
        acceleration.z += axe.z * 100000 * Time.fixedDeltaTime;
        acceleration.y += axe.y * 5000 * Time.fixedDeltaTime;

        limit_acceleration();
        //Debug.Log(velocity.y);
        //Debug.Log(acceleration.y);
        //forward
        //acceleration.x = Mathf.Clamp(tmp_acceleration.x, -10, 10);
        //up and down
        //acceleration.y = Mathf.Clamp(tmp_acceleration.y, -10, 10);
        //Mathf.Clamp(tmp_acceleration.y + axe.y * 50 * Time.deltaTime, -15, 15)
        //right left
        //acceleration.z = Mathf.Clamp(tmp_acceleration.z, -10, 10);
        //tmp_acceleration = Vector3.zero;
        //Debug.Log(axe);
        //Debug.Log(acceleration);
    }
    public void rotate_and_move_plane()
    {
        Vector3 delta_rotation = rot * rotation_speed * Time.fixedDeltaTime;
        rotation_referance.Rotate(delta_rotation);
        if(in_area)
        {
            //this part is for left and right
            if (Horizantol_input == 1)
            {
                //to right
                //acceleration.y -= Time.fixedDeltaTime;
                rot.x -= Time.fixedDeltaTime;
            }
            else if (Horizantol_input == -1)
            {
                //to left
                //acceleration.y += Time.fixedDeltaTime;
                rot.x += Time.fixedDeltaTime;
            }
            else if (Horizantol_input == 0)
            {
                rot.x = Mathf.Lerp(rot.x, 0, 0.03f);
            }
            //this part is for up and down
            if (Vertical_input == 1)
            {
                //to down
                rot.z -= Time.fixedDeltaTime;
            }
            else if (Vertical_input == -1)
            {
                //to up
                rot.z += Time.fixedDeltaTime;
            }
            else if (Vertical_input == 0)
            {
                rot.z = Mathf.Lerp(rot.z, 0, 0.03f);
            }
        }
    }
    public void rotate_vertically()
    {
        Vector3 delta_rotation = Global_rotation * Time.fixedDeltaTime;
        rotation_referance.Rotate(new Vector3(0,Global_rotation.y * Time.deltaTime ,Mathf.Abs(Global_rotation.z) * Time.deltaTime) * 2);
        //Debug.Log(rotation_referance.rotation.x);
        if (rotation_referance.rotation.eulerAngles.x< 70 && rotation_referance.rotation.eulerAngles.x > 30)
        {
            //left
            if (Global_rotation.z > -20)
            {
                Global_rotation.z = ((1 - 20 / rotation_referance.rotation.eulerAngles.x)/5) * r_s;
                Global_rotation.y = -(0.15f - Global_rotation.z/r_s) * 100;
                
            }
        }
        if(rotation_referance.rotation.eulerAngles.x >= 290 && rotation_referance.rotation.eulerAngles.x < 330)
        {
            //right
            if(Global_rotation.z < 20)
            {
                Global_rotation.z = (340 / rotation_referance.rotation.eulerAngles.x - 1) * r_s;
                Global_rotation.y = (0.17f - Global_rotation.z / r_s) * 50;
            }
        }
        else if(rotation_referance.rotation.eulerAngles.x < 30 || rotation_referance.rotation.eulerAngles.x > 330)
        {
            while(Global_rotation.z > 0)
            {
                Global_rotation.z -= Time.deltaTime;
            }
            while (Global_rotation.y > 0)
            {
                Global_rotation.y -= Time.deltaTime;
            }
        }
        
    }
    public void limit_acceleration()
    {
        if(acceleration.x > acceleration_max)
        {
            acceleration.x = acceleration_max;
        }
        else if(acceleration.x < -acceleration_max)
        {
            acceleration.x = -acceleration_max;
        }
        if (acceleration.y > acceleration_max)
        {
            acceleration.y = acceleration_max;
        }
        else if (acceleration.y < -acceleration_max)
        {
            acceleration.y = -acceleration_max;
        }
        if (acceleration.z > acceleration_max)
        {
            acceleration.z = acceleration_max;
        }
        else if (acceleration.z < -acceleration_max)
        {
            acceleration.z = -acceleration_max;
        }
    }
    public float get_y_value(float value)
    {
        if(value >= 0 && value <= 50)
        {
            return 90;
        }
        else if(value < 0)
        {
            return -90;
        }
        else
        {
            return -90;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "border")
        {
            in_area = false;
            passed_rotation = other.gameObject.GetComponent<reverse_plain>().reversed_direction;
            border_text = GameObject.Find("border text").GetComponent<TextMeshProUGUI>();
            border_text.enabled = true;
        }
    }
    private void passing_border()
    {
        //acceleration.x += axe.x * 1000 * Time.fixedDeltaTime;
        //acceleration.z += axe.z * 1000 * Time.fixedDeltaTime;
        //acceleration.y += axe.y * 500 * Time.fixedDeltaTime;

        //limit_acceleration();
        Vector3 real_rotation = new Vector3(rotation_referance.rotation.eulerAngles.x, rotation_referance.rotation.eulerAngles.y, rotation_referance.rotation.eulerAngles.z);
        if(real_rotation.x > 180)
        {
            real_rotation.x -= 360; 
        }
        if (real_rotation.y > 180)
        {
            real_rotation.y -= 360;
        }
        if (real_rotation.z > 180)
        {
            real_rotation.z -= 360;
        }
        Vector3 difference = passed_rotation - real_rotation;
        rotation_referance.Rotate(difference * Time.deltaTime);
        
        if(Vector3.Distance(difference, Vector3.zero) < 10)
        {
            in_area = true;
        }

        //rotation_referance.Rotate(axe * 90);
    }

}
