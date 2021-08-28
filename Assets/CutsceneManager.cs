using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Animation fade;

    Scene scene;

    bool delayed = false;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        if(scene.buildIndex % 2 == 1)
        {
            StartCoroutine(DelayFade(6f));
        }
        if(scene.buildIndex == 7)
        {
            AudioManager.instance.Play("rocket");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
        if (delayed)
        {
            if (scene.buildIndex % 2 == 1 && scene.buildIndex != 7)
            {
                if(scene.buildIndex == 1)
                {
                    AudioManager.instance.FadeOut("moto");
                }
                if (scene.buildIndex == 3)
                {
                    AudioManager.instance.FadeOut("car");
                }
                if (scene.buildIndex == 5)
                {
                    AudioManager.instance.FadeOut("jet");
                }

            }
        }
    }

    IEnumerator DelayFade(float time)
    {
        yield return new WaitForSeconds(time);
        fade.Play("FadeToBlack");
        if(scene.buildIndex == 1)
            AudioManager.instance.Play("moto");
        if (scene.buildIndex == 3)
            AudioManager.instance.Play("car");
        if (scene.buildIndex == 5)
            AudioManager.instance.Play("jet");

        delayed = true;

        StartCoroutine(DelayNextScene(3f));
    }

    IEnumerator DelayNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
