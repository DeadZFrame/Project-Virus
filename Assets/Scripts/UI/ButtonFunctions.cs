using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Contains UI Button Functions
public class ButtonFunctions : MonoBehaviour
{
    public Image pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if(!pauseMenu.gameObject.activeInHierarchy)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Play()
    {
        
    }
}
