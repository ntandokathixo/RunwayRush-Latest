using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{
    public AudioManager audioManager;
    public float timer = 5f;
    public Text timerText;
    private bool isPaused = false;
    private bool isGameOver = false;
    public GameObject gameOverPanel;
    public Button retryButton;
    public Slider ProgressSlider;


    public void Start()
    {
        //audioManager = FindFirstObjectByType<AudioManager>();
        //audioManager.musicSource.Stop();
        audioManager = AudioManager.instance;

        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene!");
            return;
        }

        if (audioManager.musicSource != null)
        {
            audioManager.musicSource.Stop();
        }
        else
        {
            Debug.LogError("AudioManager.musicSource is not assigned!");
        }
        Time.timeScale = 0;

    }
        void Update()
    {
        if (!isPaused && timer > 0f)
        {
            
            timerText.text = Mathf.Ceil(timer) + "";
        }
        else if (timer <= 0f)
        {
            timer = 0f;
            timerText.text = "0 seconds";
            retryButton.gameObject.SetActive(true);
        }

        if (!isGameOver)
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0)
            {
                TriggerGameOver();

            }
        }

        if (timer <=0)
        {
            timer = 0;
        }

        
     }

    // Method to pause the timer
    public void PauseTimer()
    {
        isPaused = true;
        Debug.Log("Timer Paused");
    }

    // Method to resume the timer
    public void ResumeTimer()
    {
        isPaused = false;
        Debug.Log("Timer Resumed. isPaused: " + isPaused);
    }

    public void startTheGame()
    {
        Time.timeScale = 1;
        audioManager.musicSource.Play();
    }


    void TriggerGameOver()
    {
        isGameOver = true;  
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over");
    }
}
