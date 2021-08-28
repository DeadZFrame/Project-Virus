using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public Animation credits, header;
    bool isPlayed = false;

    private void Update()
    {
        if (!header.isPlaying)
        {
            if (!isPlayed)
            {
                credits.Play();
                isPlayed = true;
            }
            if (!credits.isPlaying)
            {
                StartCoroutine(DelayExit(5f));
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator DelayExit(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}
