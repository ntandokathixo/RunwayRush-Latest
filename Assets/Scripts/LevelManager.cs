using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level_Manager : MonoBehaviour
{
    public int currentLevel = 1;

    // External references
    public  TextMeshProUGUI messageText;
    public RunwayProgressBar progressBar;
    public RunwayPointSystem pointsSystem;
    //public SetChecker setChecker; 
    public TimerSystem timerSystem;

    public GameObject tryAgainPanel;
    public Button yesButton;
    public Button noButton;

    private int setsCompleted = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartLevel(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSystem.timer > 0 && setsCompleted < RequiredSets())
        {
            if (PlayerSwappedModels()) // placeholder
                UpdateModelPositions(); // placeholder

            //if (setChecker.CheckForSets()) // This should return true if a new set was completed
            //{
            //    setsCompleted++;
            //    progressBar.FillOneBlock();
            //    pointsSystem.AddSetPoints();
            //    ShowGlowEffect(setsCompleted);
            //}
        }
        else if (timerSystem.timer <= 0 && setsCompleted < RequiredSets())
        {
            messageText.text = "We couldn’t save the show!";
            tryAgainPanel.SetActive(true);
            SetupRetryButtons();
        }
        else if (setsCompleted >= RequiredSets())
        {
            messageText.text = "You conquered the runway!";
            currentLevel++;
            Invoke("StartNextLevel", 2f); // short delay before starting next level
        }
    }
    void StartLevel(int level)
    {
        setsCompleted = 0;
        timerSystem.timer = 60f;

        switch (level)
        {
            case 1:
                messageText.text = "Level 1 - Street";
                //progressBar.SetLevel(1);
                break;
            case 2:
                messageText.text = "Level 2 - Warehouse";
                //progressBar.SetLevel(2);
                break;
            case 3:
                messageText.text = "Level 3 - Rooftop";
                //progressBar.SetLevel(3);
                break;
            default:
                messageText.text = "We’ve conquered the runway! See you again soon!";
                return;
        }

        ShowModels(level);
    }

    void ShowModels(int level)
    {
        int modelCount = level * 3; // Adjusted if needed for level 2 (5) and level 3 (7)
        Debug.Log("Displaying " + modelCount + " models.");
    }

    void SetupRetryButtons()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() =>
        {
            tryAgainPanel.SetActive(false);
            messageText.text = "Great! This time we'll show the runway who's boss!";
            StartLevel(currentLevel);
        });

        noButton.onClick.AddListener(() =>
        {
            tryAgainPanel.SetActive(false);
            messageText.text = "We'll take over the fashion scene next time, see you soon!";
            Application.Quit(); // Only works in builds
        });
    }

    void StartNextLevel()
    {
        if (currentLevel <= 3)
        {
            StartLevel(currentLevel);
        }
        else
        {
            messageText.text = "Fashion history made! All levels complete.";
        }
    }

    int RequiredSets()
    {
        // Level 1 = 3 sets, Level 2 = 5 sets, Level 3 = 7 sets
        return currentLevel switch
        {
            1 => 3,
            2 => 5,
            3 => 7,
            _ => 0,
        };
    }

    bool PlayerSwappedModels()
    {
        // Placeholder for now. Replace with your input or swap logic.
        return false;
    }

    void UpdateModelPositions()
    {
        // Placeholder for actual model rearrangement logic
    }

    void ShowGlowEffect(int setNumber)
    {
        Debug.Log("Glow effect for set: " + setNumber);
    }
}
