using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_manager : MonoBehaviour
{
    public float max_time_in_seconds;
    public static float current_time;
    public GameObject end_text;
    public GameObject time_txt;

    private void Awake()
    {
        current_time = max_time_in_seconds;
    }
    private void Update()
    {
        time_going();
    }
    public void time_going()
    {
        current_time -= Time.deltaTime;
        if(current_time < 0)
        {
            end_text.SetActive(true);
        }
    }
}
