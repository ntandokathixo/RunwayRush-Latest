using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{
    public float timer = 45f;
    public Text timerText;
    private bool isPaused = false;
    private bool isGameOver = false;
    public GameObject gameOverText;

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
            Debug.Log("Show’s Over!");
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


    void TriggerGameOver()
    {
        isGameOver = true;  
        Time.timeScale = 0f;
        gameOverText.SetActive(true);
        Debug.Log("Game Over");
    }
}
