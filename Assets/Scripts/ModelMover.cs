using UnityEngine;

public class ModelMover : MonoBehaviour
{
    public Transform[] pathPoints;         // Waypoints along the model's runway loop
    public float moveSpeed = 2f;           // Walking speed
    public float pointThreshold = 0.05f;   // Distance to consider "arrived" at a point

    private int currentPointIndex = 0;

    void Update()
    {
        if (pathPoints == null || pathPoints.Length == 0)
            return;

        Transform targetPoint = pathPoints[currentPointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // If close enough to current target point, switch to the next one
        float distanceToPoint = Vector3.Distance(transform.position, targetPoint.position);
        if (distanceToPoint <= pointThreshold)
        {
            currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
        }
    }
}
