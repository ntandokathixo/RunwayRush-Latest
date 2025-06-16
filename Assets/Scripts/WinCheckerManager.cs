//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.UIElements;

//public class WinCHeckerManager : MonoBehaviour
//{
//    public List<GameObject> Models;
//    public TimerSystem Timer;
//    public GameObject WinPanel;
//    public ParticleSystem WinningParticle, WinningParticle2;



//    private void Update()
//    {
//        if(Models.Count == 9)
//        {
//            WinPanel.SetActive(true);
//            //Put the Winning condition Here and stop the Timer
//            WinningParticle.Play();
//            WinningParticle2.Play();
//        }

//        int Count = Models.Count;

//        Timer.ProgressSlider.value = Count;
//    }
//}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCHeckerManager : MonoBehaviour
{
    public List<GameObject> Models;
    public TimerSystem Timer;
    public GameObject WinPanel;
    public ParticleSystem WinningParticle, WinningParticle2;

    private int requiredModelCount;
    private Level_Manager levelManager;

    private void Start()
    {
        // Find the LevelManager in the scene
        levelManager = Object.FindFirstObjectByType<Level_Manager>();

        if (levelManager != null)
        {
            int currentLevel = levelManager.currentLevel; // Update this line if your variable is named differently

            switch (currentLevel)
            {
                case 1:
                    requiredModelCount = 9;
                    break;
                case 2:
                    requiredModelCount = 15;
                    break;
                case 3:
                    requiredModelCount = 21;
                    break;
                default:
                    Debug.LogWarning("Unsupported level. Defaulting model count to 9.");
                    requiredModelCount = 9;
                    break;
            }

            // Set max value of the progress slider to required count
            if (Timer.ProgressSlider != null)
                Timer.ProgressSlider.maxValue = requiredModelCount;
        }
        else
        {
            Debug.LogError("LevelManager not found in the scene!");
            requiredModelCount = 9; // fallback
        }
    }

    private void Update()
    {
        int currentCount = Models.Count;

        if (currentCount == requiredModelCount)
        {
            WinPanel.SetActive(true);
            WinningParticle.Play();
            WinningParticle2.Play();

            Timer.enabled = false;
        }

        if (Timer.ProgressSlider != null)
            Timer.ProgressSlider.value = currentCount;
    }
}

