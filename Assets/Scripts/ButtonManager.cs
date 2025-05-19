using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void restart()
    {
       string CurrentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(CurrentScene);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
 
}
