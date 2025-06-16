//using UnityEngine;
//using System.Collections.Generic;

//public class ModelMaterialAssigner : MonoBehaviour
//{
//    [Header("Assign exactly 3 materials here")]
//    public Material[] materials; // Assign 3 distinct materials in the Inspector

//    [Header("Assign your 9 model GameObjects here")]
//    public GameObject[] models; // Assign your 9 model GameObjects in the Inspector

//    void Start()
//    {
//        AssignMaterials();
//    }

//    void AssignMaterials()
//    {
//        // Validate inputs
//        if (materials.Length != 3)
//        {
//            Debug.LogError("Please assign exactly 3 materials.");
//            return;
//        }

//        if (models.Length != 9)
//        {
//            Debug.LogError("Please assign exactly 9 model GameObjects.");
//            return;
//        }

//        // Create a list with each material repeated 3 times
//        List<Material> materialPool = new List<Material>();
//        foreach (Material mat in materials)
//        {
//            for (int i = 0; i < 3; i++)
//            {
//                materialPool.Add(mat);
//            }
//        }

//        // Shuffle the material pool
//        Shuffle(materialPool);

//        // Assign materials to models
//        for (int i = 0; i < models.Length; i++)
//        {
//            Renderer renderer = models[i].GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                renderer.material = materialPool[i];
//            }
//            else
//            {
//                Debug.LogWarning($"Model at index {i} does not have a Renderer component.");
//            }
//        }
//    }

//    // Fisher-Yates shuffle algorithm
//    void Shuffle(List<Material> list)
//    {
//        for (int i = list.Count - 1; i > 0; i--)
//        {
//            int j = Random.Range(0, i + 1);
//            Material temp = list[i];
//            list[i] = list[j];
//            list[j] = temp;
//        }
//    }
//}

using UnityEngine;
using System.Collections.Generic;

public class ModelMaterialAssigner : MonoBehaviour
{
    public Material[] materials; // Assign up to 7 materials in Inspector
    public GameObject[] models;  // Assign up to 21 model GameObjects in Inspector

    private int currentLevel;
    private int requiredMaterialCount;
    private int requiredModelCount;

    private void Start()
    {
        Level_Manager levelManager = FindFirstObjectByType<Level_Manager>();
        if (levelManager != null)
        {
            currentLevel = levelManager.currentLevel;
        }
        else
        {
            Debug.LogWarning("LevelManager not found, defaulting to Level 1.");
            currentLevel = 1;
        }

        switch (currentLevel)
        {
            case 1:
                requiredMaterialCount = 3;
                requiredModelCount = 9;
                break;
            case 2:
                requiredMaterialCount = 5;
                requiredModelCount = 15;
                break;
            case 3:
                requiredMaterialCount = 7;
                requiredModelCount = 21;
                break;
            default:
                Debug.LogError("Unsupported level detected in LevelManager.");
                return;
        }

        // Validate
        if (materials.Length < requiredMaterialCount)
        {
            Debug.LogError($"Please assign at least {requiredMaterialCount} materials.");
            return;
        }

        if (models.Length < requiredModelCount)
        {
            Debug.LogError($"Please assign at least {requiredModelCount} model GameObjects.");
            return;
        }

        AssignMaterials();
    }

    void AssignMaterials()
    {
        // Create a list with each material repeated 3 times
        List<Material> materialPool = new List<Material>();
        for (int i = 0; i < requiredMaterialCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                materialPool.Add(materials[i]);
            }
        }

        // Shuffle material list
        Shuffle(materialPool);

        // Assign materials to the models
        for (int i = 0; i < requiredModelCount; i++)
        {
            Renderer renderer = models[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materialPool[i];
            }
            else
            {
                Debug.LogWarning($"Model at index {i} has no Renderer component.");
            }
        }
    }

    // Fisher-Yates Shuffle
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
