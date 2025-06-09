using System;
using UnityEngine;

public class ModelRandomization : MonoBehaviour
{
    void Start()
    {
        System.Random rnd = new System.Random(0);
        int numberOfModels = 9;

        // Define available colors
        string[] colors = { "Red", "Blue", "Green" };

        // Array to store models with assigned colors
        Model[] models = new Model[numberOfModels];

        // Assign random colors to models
        for (int i = 0; i < numberOfModels; i++)
        {
            int randomColorIndex = rnd.Next(colors.Length);
            models[i] = new Model(colors[randomColorIndex]);
        }

        // Shuffle models for random placement
        Shuffle(models, rnd);

        // Display the randomized model placements
        Debug.Log("Randomized Model Placements:");
        for (int i = 0; i < numberOfModels; i++)
        {
            Debug.Log($"Model {i + 1}: {models[i].Color}");
        }
    }

    // Fisher-Yates shuffle algorithm
    static void Shuffle(Model[] array, System.Random rnd)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    // Update is called once per frame (optional)
    void Update()
    {

    }
}

// Model class representing each model
class Model
{
    public string Color { get; private set; }

    public Model(string color)
    {
        Color = color;
    }
}