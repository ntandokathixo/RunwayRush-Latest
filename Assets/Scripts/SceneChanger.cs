using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))

        { 
            SceneManager.LoadScene(sceneName); 
        
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
}