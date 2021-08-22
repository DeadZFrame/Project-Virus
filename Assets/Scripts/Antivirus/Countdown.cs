using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float countdown = 30;
    private void Update()
    {
        if(countdown >= 0)
        {
            countdown -= Time.fixedDeltaTime;
        }
    }
}
