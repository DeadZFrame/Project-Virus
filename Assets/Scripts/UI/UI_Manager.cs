using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    PlayerController player;
    public PlayerBase playerBase;

    public TextMeshProUGUI speedometer;
    public Slider healthBar;

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
        healthBar.GetComponent<Slider>().value = playerBase.health/100;    
    }

    public void Speedometer()
    {
        if (player.speed > 0)
            speedometer.text = (player.speed * 10).ToString("0") + "km/h";
        else speedometer.text = (-player.speed * 10).ToString("0") + "km/h";
    }
}
