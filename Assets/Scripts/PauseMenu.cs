using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Update is called once per frame
    public void Pause()
    {
        Time.timeScale = 0f;    
    }

    public void Winner()
    {
        Time.timeScale = 0.5f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
