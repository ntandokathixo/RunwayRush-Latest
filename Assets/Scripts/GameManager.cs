using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void ExitGame()
    { 
        Application.Quit();
        Debug.Log("Exiting"); 
    }
}
