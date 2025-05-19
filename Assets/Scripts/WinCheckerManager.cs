using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinCHeckerManager : MonoBehaviour
{
    public List<GameObject> Models;
    public TimerSystem Timer;
    private void Update()
    {
        if(Models.Count == 9)
        {
            //Put the Winning condition Here and stop the Timer
            Time.timeScale = 0;
        }
    }
}
