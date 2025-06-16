using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))

        { 
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 0;
        
        }

        else

        { 
            Debug.LogError("Scene name emtpty! Please enter valid scene name.");
        
        }


    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

    }

    public void GoToLevelOne()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1");
    }


    public void GoToLevelTwo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_2");
    }


    public void GoToLevelThree()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_3");
    }
}