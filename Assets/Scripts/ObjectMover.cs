using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Waypoints (should be placed in order)")]
    public List<Transform> waypoints;

    [Header("Objects to move (assign in Inspector)")]
    public List<GameObject> objects;

    [Header("Settings")]
    public float moveSpeed = 2f;
    public int numb_model;
    public bool loopEnabled = false;

    private Dictionary<GameObject, int> objectIndices = new Dictionary<GameObject, int>();
    private bool[] isOccupied;

    void Start()
    {
        int count = Mathf.Min(waypoints.Count, objects.Count);
        isOccupied = new bool[waypoints.Count];

        // Randomize which 9 waypoints get an object
        List<int> availableSpots = new List<int>();
        for (int i = 0; i < numb_model; i++) availableSpots.Add(i);

        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, availableSpots.Count);
            int pointIndex = availableSpots[rand];
            availableSpots.RemoveAt(rand);

            GameObject obj = objects[i];
            obj.transform.position = waypoints[pointIndex].position;
            objectIndices[obj] = pointIndex;
            isOccupied[pointIndex] = true;
        }
    }

    void Update()
    {
        List<GameObject> objectList = new List<GameObject>(objectIndices.Keys);

        foreach (GameObject obj in objectList)
        {
            int currentIndex = objectIndices[obj];
            int nextIndex = currentIndex + 1;

            if (nextIndex < waypoints.Count)
            {
                // If next is clear, move there
                if (!isOccupied[nextIndex])
                {
                    MoveTowards(obj, currentIndex, nextIndex);
                }
            }
            else if (loopEnabled)
            {
                // Loop to first available spot
                for (int i = 0; i < waypoints.Count; i++)
                {
                    if (!isOccupied[i])
                    {
                        MoveTowards(obj, currentIndex, i);
                        Animator modelAnimator = obj.transform.GetChild(0).GetComponent<Animator>();
                        modelAnimator.SetBool("idle", true);
                        break;
                    }
                }
            }
            // else: do nothing, they’re at the end and loop is off
        }
    }

    void MoveTowards(GameObject obj, int currentIndex, int targetIndex)
    {
        Transform target = waypoints[targetIndex];
        float step = moveSpeed * Time.deltaTime;

        obj.transform.position = Vector3.MoveTowards(obj.transform.position, target.position, step);

        if (Vector3.Distance(obj.transform.position, target.position) < 0.05f)
        {
            isOccupied[currentIndex] = false;
            isOccupied[targetIndex] = true;
            objectIndices[obj] = targetIndex;
        }
    }
}