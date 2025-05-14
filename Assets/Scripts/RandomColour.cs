using UnityEngine;
using System.Collections.Generic;

public class ModelMaterialAssigner : MonoBehaviour
{
    [Header("Assign exactly 3 materials here")]
    public Material[] materials; // Assign 3 distinct materials in the Inspector

    [Header("Assign your 9 model GameObjects here")]
    public GameObject[] models; // Assign your 9 model GameObjects in the Inspector

    void Start()
    {
        AssignMaterials();
    }

    void AssignMaterials()
    {
        // Validate inputs
        if (materials.Length != 3)
        {
            Debug.LogError("Please assign exactly 3 materials.");
            return;
        }

        if (models.Length != 9)
        {
            Debug.LogError("Please assign exactly 9 model GameObjects.");
            return;
        }

        // Create a list with each material repeated 3 times
        List<Material> materialPool = new List<Material>();
        foreach (Material mat in materials)
        {
            for (int i = 0; i < 3; i++)
            {
                materialPool.Add(mat);
            }
        }

        // Shuffle the material pool
        Shuffle(materialPool);

        // Assign materials to models
        for (int i = 0; i < models.Length; i++)
        {
            Renderer renderer = models[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materialPool[i];
            }
            else
            {
                Debug.LogWarning($"Model at index {i} does not have a Renderer component.");
            }
        }
    }

    // Fisher-Yates shuffle algorithm
    void Shuffle(List<Material> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Material temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
