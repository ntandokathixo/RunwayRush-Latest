using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
 
        public GameObject settingsPanel;
        public GameObject mainMenuPanel;
        public void StartGame()
        {
            SceneManager.LoadScene("RunwayLoading");
        }

        public void OpenSettings()
        {
            settingsPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void CloseSettings()
        {
            settingsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }

    }

  
   