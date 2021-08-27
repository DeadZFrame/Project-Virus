using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour
{
    public void load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
