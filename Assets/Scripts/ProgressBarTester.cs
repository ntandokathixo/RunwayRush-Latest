using UnityEngine;

public class ProgressBarTester : MonoBehaviour
{
    public RunwayProgressBar progressBar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            progressBar.IncreaseProgress();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            progressBar.DecreaseProgress();
        }
    }
}
