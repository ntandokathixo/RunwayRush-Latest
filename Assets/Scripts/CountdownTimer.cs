using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;
    private float countdownTime = 3f;
    private bool countdownActive = false;

    void Update()
    {
        if (!countdownActive) return;

        countdownTime -= Time.deltaTime;

        int secondsLeft = Mathf.CeilToInt(countdownTime);
        countdownText.text =  secondsLeft + "";

        if (countdownTime <= 0)
        {
            countdownActive = false;
            SceneManager.LoadScene("Level_1"); 
        }
    }

    // Call this from your Start button
    public void StartCountdown()
    {
        countdownTime = 3f;
        countdownActive = true;
        countdownText.gameObject.SetActive(true); 
    }
}