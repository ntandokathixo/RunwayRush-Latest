using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject npc;
    public Canvas pauseCanvas; 
    public GameObject pauseConfirmationPopup; 
    public TimerSystem timerSystem; 

    void Start()
    {
       
        if (timerSystem == null)
        {
            timerSystem = Object.FindAnyObjectByType<TimerSystem>();
        }    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenPauseConfirmation();
        }

        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.R)) ResumeGame();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("We'll take over the fashion scene next time, see you soon");
                Application.Quit();
            }
        }
    }

  
    void OpenPauseConfirmation()
    {
        if (pauseConfirmationPopup != null)
        {
            pauseConfirmationPopup.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame() Called");

        // Unpause the game and resume time
        Time.timeScale = 1f; 
        Debug.Log("Time.timeScale set to: " + Time.timeScale);

        // Resume the timer
        if (timerSystem != null)
        {
            timerSystem.ResumeTimer();  // Ensure this is unpausing the timer
        }

        // Hide the pause screen and NPC
        if (pauseCanvas != null) pauseCanvas.gameObject.SetActive(false);
        if (npc != null) npc.SetActive(false);

        // Hide the confirmation popup
        if (pauseConfirmationPopup != null) pauseConfirmationPopup.SetActive(false);

        Debug.Log("Resuming game and timer!");
    }

       public void ConfirmPause()
    {
        Debug.Log("ConfirmPause Called");

        isPaused = true;
        Time.timeScale = 0f;

        // Show the pause screen and NPC again
        if (pauseCanvas != null) pauseCanvas.gameObject.SetActive(true);
        if (npc != null) npc.SetActive(true);

        
        if (pauseConfirmationPopup != null) pauseConfirmationPopup.SetActive(false);

        Debug.Log("Fashion history is in the making, let’s finish strong!");
    }
}