//using System.Collections.Generic;
//using System.Drawing;
//using UnityEngine;
//public class SetChecker : MonoBehaviour
//{
//    public List<Model> modelsInLine; // These are the models on the runway in order
//    public RunwayProgressBar progressBar; // Reference to your progress bar
//    public RunwayPointSystem pointsSystem; // Reference to your points system
//    private List<int> matchedIndices = new List<int>(); // Keep track of matched sets

//    public bool CheckForSets()
//    {
//        bool setFound = false;

//        for (int i = 0; i < modelsInLine.Count - 2; i++)
//        {
//            Model modelA = modelsInLine[i];
//            Model modelB = modelsInLine[i + 1];
//            Model modelC = modelsInLine[i + 2];

//            if (modelA.color == modelB.color && modelB.color == modelC.color)
//            {
//                if (!matchedIndices.Contains(i))
//                {
//                    matchedIndices.Add(i);

//                    Debug.Log("Set completed with color: " + modelA.color);

//                    // Update systems
//                    progressBar.FillOneBlock();
//                    pointsSystem.AddSetPoints();

//                    setFound = true;
//                }
//            }
//        }

//        return setFound;
//    }
//}

