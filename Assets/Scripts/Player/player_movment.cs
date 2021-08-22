using UnityEngine;

public class player_movment : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 5f;
    public float turnSmoothTime = 0.5f;
    float turnSmoothVelocity = 0.0f;

    private void Update()
    {
        move();
    }
    private void move()
    {
        //get input axis
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        //rotation and movment
        if(direction.magnitude > 0.1f)
        {

            //rotate
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            //move
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
    /*private float increase_angle(float angle, float float_increase_speed)
    {
        if(Mathf.Abs(turnSmoothVelocity) <= Mathf.Abs(angle))
        {
            turnSmoothVelocity += float_increase_speed * Time.deltaTime;
        }
        if(Mathf.Abs(turnSmoothVelocity) > 180)
        {
            turnSmoothVelocity = 180;
        }
        return turnSmoothVelocity;
    }*/
}
