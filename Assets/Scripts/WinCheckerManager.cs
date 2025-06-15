using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WinCHeckerManager : MonoBehaviour
{
    public List<GameObject> Models;
    public TimerSystem Timer;
    public GameObject WinPanel;



    private void Update()
    {
        if(Models.Count == 9)
        {
            WinPanel.SetActive(true);
            //Put the Winning condition Here and stop the Timer
            Time.timeScale = 0;
        }

        int Count = Models.Count;

        Timer.ProgressSlider.value = Count;
    }
}
