using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    GameObject[] @object;
    int i = 0;
    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex % 2 == 0 && SceneManager.GetActiveScene().buildIndex != 8)
        {
            @object = GameObject.FindGameObjectsWithTag("music");

            if (@object.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
            while (i < @object.Length)
            {
                Destroy(@object[i]); Debug.Log("exterminate");
                i++;
            }
        }
        PlayerBase.finished = false;
    }

    private void Update()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (PlayerBase.finished)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
