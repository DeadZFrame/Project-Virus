using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    PlayerController player;
    public Transform car;

    public TextMeshProUGUI speedometer;
    public Slider healthBar;

    public Vector3 speedometerOffset, velocity = Vector3.zero;

    private void Awake()
    {
        speedometer.GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        Speedometer();
        HealthBar();
    }

    public void HealthBar()
    {
        healthBar.GetComponent<Slider>().value = PlayerBase.health/100;    
    }

    public void Speedometer() //Method for showing car's speed near of it
    {
        if (player.speed > 0)
            speedometer.text = (player.speed * 5).ToString("0") + "km/h";
        else speedometer.text = (-player.speed * 5).ToString("0") + "km/h";

        //Finds players position from camera's sight and allows UI elements in canvas to follow player
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(car.transform.position) + speedometerOffset; 
        Vector3 smoothToPos = Vector3.SmoothDamp(speedometer.gameObject.transform.position, wantedPos, ref velocity, 0.15f);

        speedometer.gameObject.transform.position = smoothToPos;
    }
}
