using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    Countdown cd;

    private void Awake()
    {
        countdownText.GetComponent<TextMeshProUGUI>();
        cd = GameObject.Find("Security").GetComponent<Countdown>();
    }

    private void Update()
    {
        countdownText.text = cd.countdown.ToString("0");
    }
}
