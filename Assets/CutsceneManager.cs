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
            AudioManager.instance.Play("Moto");
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
                AudioManager.instance.FadeOut("Moto");
            }
        }
    }

    IEnumerator DelayFade(float time)
    {
        yield return new WaitForSeconds(time);
        fade.Play("FadeToBlack");
        if(scene.buildIndex != 7)
            AudioManager.instance.Play("Moto");
        delayed = true;

            StartCoroutine(DelayNextScene(3f));
    }

    IEnumerator DelayNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
