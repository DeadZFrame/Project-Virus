using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains UI Button Functions
public class ButtonFunctions : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }
}
