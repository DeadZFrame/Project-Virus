using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Contains UI Button Functions
public class ButtonFunctions : MonoBehaviour
{
    public Image pauseMenu;
    public Animation mainMenuPlayAnimation;
    public GameObject mainMenuVerticalGroup, settingsMenu, controlsMenu, creditsMenu;
    public AudioSource audioSource;
    public Slider volumeSlider;

    Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if(scene.buildIndex ==0) audioSource.volume = 0.1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && scene.buildIndex != 0)
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
        if(scene.buildIndex == 0 && mainMenuPlayAnimation.gameObject.activeInHierarchy)
        {
            if (!mainMenuPlayAnimation.isPlaying)
            {
                SceneManager.LoadScene(scene.buildIndex + 1);
            }
            audioSource.volume -= 0.05f * Time.deltaTime;
        }
    }

    public void Pause() //Pauses game in levels
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue() //Unpauses game
    {
        Time.timeScale = 1f;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Reload()
    {
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void Play() //Starts game from main menu
    {
        mainMenuPlayAnimation.gameObject.SetActive(true);
        mainMenuPlayAnimation.Play();
    }

    public void OpenCloseSettings() //Opens Settings Menu
    {
        if (!settingsMenu.activeInHierarchy)
        {
            mainMenuVerticalGroup.SetActive(false);
            settingsMenu.SetActive(true);
        }
        else
        {
            mainMenuVerticalGroup.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenCloseCredits()
    {
        if (!creditsMenu.activeInHierarchy)
        {
            mainMenuVerticalGroup.SetActive(false);
            creditsMenu.SetActive(true);
        }
        else
        {
            mainMenuVerticalGroup.SetActive(true);
            creditsMenu.SetActive(false);
        }
    }

    public void OpenCloseControls()
    {
        if (!controlsMenu.activeInHierarchy)
        {
            settingsMenu.SetActive(false);
            controlsMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(true);
            controlsMenu.SetActive(false);
        }

    }
}
