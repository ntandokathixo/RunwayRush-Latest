using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Waypoints (should be placed in order)")]
    public List<Transform> waypoints; //list of WPs

    [Header("Objects to move (assign in Inspector)")]
    public List<GameObject> objects; //list of models 

    [Header("Settings")]
    public float moveSpeed = 2f; //speed that the models move
    public int numb_model;          // numb of models to place on spawnpoints
    public bool loopEnabled = false; //whether objects should loop back to first WP when reaching the end

    public bool idle = false;
    public bool isWalking = false;

    private Dictionary<GameObject, int> objectIndices = new Dictionary<GameObject, int>();
    private bool[] isOccupied; //tracks which WPs are currently occupied 

    void Start()
    {
        //initialize the occupied array
        int count = Mathf.Min(waypoints.Count, objects.Count);
        isOccupied = new bool[waypoints.Count];

        //create a list of available spots (first numbmodel WPs) 
        List<int> availableSpots = new List<int>();
        for (int i = 0; i < numb_model; i++) availableSpots.Add(i);

        // Randomize which 9 waypoints get an object
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, availableSpots.Count); //pick a random avaliable spot
            int pointIndex = availableSpots[rand];      //get WP index
            availableSpots.RemoveAt(rand); //remove the used spot from the list 

            GameObject obj = objects[i];
            obj.transform.position = waypoints[pointIndex].position; //move model to the waypoint
            objectIndices[obj] = pointIndex;        //record its current WP index
            isOccupied[pointIndex] = true;          //mark WP as occupied
        }
    }

    void Update()
    {
        //make a copy of the list of objects to iterate over
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
                int LoopIndex = (currentIndex + 1) % waypoints.Count;

                //Look ahead cyclically until a free WP is found
                for (int i = 0; i < waypoints.Count; i++)
                {
                    int tryIndex = (LoopIndex + 1) % waypoints.Count;

                    if (!isOccupied[tryIndex])
                    {
                        MoveTowards(obj, currentIndex, i);
                        break;
                    }

                }
            }
            // else: do nothing, they’re at the end and loop is off
        }
    }
    
    void MoveTowards(GameObject obj, int currentIndex, int targetIndex) //function that moves model
    {
        Transform target = waypoints[targetIndex];
        float step = moveSpeed * Time.deltaTime;

        // Get Animator component on the object (or child)
        Animator anim = obj.GetComponentInChildren<Animator>();
        if (anim != null)
        {
            float distance = Vector3.Distance(obj.transform.position, target.position);

            // Set animator based on whether object is moving or close to target
            if (distance > 0.05f)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("idle", false);
            }
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("idle", true);
            }
        }

        // Move the object
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, target.position, step);

        // If close enough to target, update tracking
        if (Vector3.Distance(obj.transform.position, target.position) < 0.05f)
        {
            isOccupied[currentIndex] = false;
            isOccupied[targetIndex] = true;
            objectIndices[obj] = targetIndex;
        }
    }
}