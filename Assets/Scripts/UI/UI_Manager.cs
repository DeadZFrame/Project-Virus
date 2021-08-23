using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    PlayerController player;

    public TextMeshProUGUI speedometer;

    private void Awake()
    {
        speedometer.GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(player.speed > 0)
            speedometer.text = (player.speed * 10).ToString("0") + "km/h";
        else speedometer.text = (-player.speed * 10).ToString("0") + "km/h";
    }
}
