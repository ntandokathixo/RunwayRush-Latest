using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunwayProgressBar : MonoBehaviour
{
    public Color enabledColor; // All possible blocks (e.g. 7 max for level 3)
    public Color disabledColor;
    public bool StartFull = true;


    [SerializeField]
    int MaxValue = 7;
    [SerializeField]
    int MinValue = 0;
    [SerializeField]
    int currentValue;

    [SerializeField]
     public List<Image> ProgressSteps;

    private void Start()
    {
        MaxValue = transform.childCount;

        ProgressSteps = new List<Image>();

        for (int i = 0; i < MaxValue; i++)

        {
            ProgressSteps.Add(transform.GetChild(i).GetComponent<Image>());

        }

        InititateProgressBar(StartFull);

    }

    void ChangeSpriteColor(int index, Color newColour)
    {
        ProgressSteps[index].color = newColour;
       
       
            Debug.Log($"Changing color of ProgressStep {index} to {newColour}");
            ProgressSteps[index].color = newColour;
        
    }

    public void InititateProgressBar(bool isFull) //fill or reset
    {
        if (isFull)
        {
            for (int i = 0; i < MaxValue; i++)
            {
                ChangeSpriteColor(i, enabledColor);
            }

            currentValue = MaxValue;

        }
        else
        {
            for (int i = 0; i < MaxValue; ++i)
            {
                ChangeSpriteColor(i, disabledColor);
            }
            currentValue = 0;
        }
    }

    public void IncreaseProgress()
    {
        if (currentValue == MaxValue) return;

        currentValue++;
        ChangeSpriteColor(currentValue - 1, enabledColor);
    }
    public void DecreaseProgress()
    {
        if (currentValue == MinValue) return;

        ChangeSpriteColor(currentValue - 1, disabledColor);
        currentValue--;
    }

    public int GetProgress()
    {
        return currentValue;
    }


}