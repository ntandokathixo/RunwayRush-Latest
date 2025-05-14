using UnityEngine;
using TMPro;

public class RunwayPointSystem : MonoBehaviour
{
    public int points = 0;
    public int pointsPerSet = 5;
    public TextMeshProUGUI pointsText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdatePointsText();
    }

    public void AddSetPoints()
    {
        points += pointsPerSet;
        UpdatePointsText();
        Debug.Log(points);
    }

    
    void UpdatePointsText()
    {
        if (pointsText != null)
        pointsText.text = "" + points;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { AddSetPoints(); } 
    }
}

