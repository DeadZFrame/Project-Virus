using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private MotorcycleController motorcycle;
    [SerializeField] private CarController car;

    public TextMeshProUGUI speedometer;
    public TextMeshProUGUI time_txt;
    public Slider healthBar;

    public Image wayPoint;
    public Renderer target;
    public GameObject leftNavAnim, RightNavAnim;
    public Transform jetGFX;

    public Vector3 speedometerOffset;
    Vector3 velocity = Vector3.zero;

    Scene scene;

    private void Awake()
    {
        speedometer.GetComponent<TextMeshProUGUI>();
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        Speedometer();
        HealthBar();
        time_decrease();
    }

    public void HealthBar()
    {
        healthBar.GetComponent<Slider>().value = PlayerBase.health/100;
    }

    public void Speedometer() //Method for showing car's speed near of it
    {
        if (scene.name == "car_scene")
        {
            if (car.speedval > 0)
                speedometer.text = (car.speedval * 40).ToString("f1") + "km/h";
            else speedometer.text = (car.speedval * 40).ToString("f1") + "km/h";

            Vector3 motoPos = Camera.main.WorldToScreenPoint(car.transform.position) + speedometerOffset;
            Vector3 smoothToPos = Vector3.SmoothDamp(speedometer.gameObject.transform.position, motoPos, ref velocity, 0.15f);

            speedometer.gameObject.transform.position = smoothToPos;
        }
        if (scene.name == "2012-Level1")
        {
            if (motorcycle.speedval > 0)
                speedometer.text = (motorcycle.speedval * 40).ToString("f1") + "km/h";
            else speedometer.text = (motorcycle.speedval * 40).ToString("f1") + "km/h";

            Vector3 carPos = Camera.main.WorldToScreenPoint(motorcycle.transform.position) + speedometerOffset;
            Vector3 smoothToPos = Vector3.SmoothDamp(speedometer.gameObject.transform.position, carPos, ref velocity, 0.15f);

            speedometer.gameObject.transform.position = smoothToPos;
        }

        if (scene.name == "deneme")
        {
            if (target.isVisible)
            {
                wayPoint.gameObject.SetActive(true);
                Vector3 targetPos = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
                wayPoint.gameObject.transform.position = targetPos;
            }
            else
            {
                wayPoint.gameObject.SetActive(false);
                if (jetGFX.rotation.y > 10)
                {
                    RightNavAnim.SetActive(false);
                    leftNavAnim.SetActive(true);
                }
                else if(jetGFX.rotation.y < -10)
                {
                    leftNavAnim.SetActive(false);
                    RightNavAnim.SetActive(true);
                }
            }
        }

    }
    public void time_decrease()
    {
        int time = (int)time_manager.current_time;
        time_txt.text = time.ToString();
    }
}