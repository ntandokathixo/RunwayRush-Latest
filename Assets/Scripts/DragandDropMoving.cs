using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragAndDropMoving : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPosition;
    private bool isDragging = false;

    public List<string> Tags; // Valid tags to allow swapping with
    public float swapDistance = 1f;

    public TimerSystem timerScript; // Reference to countdown timer

    private ModelMover modelMover; // Movement script (e.g., looping model walking)

    void Start()
    {
        modelMover = GetComponent<ModelMover>(); // Assigns model movement script
    }

    void OnMouseDown()
    {
        if (timerScript != null && timerScript.timer <= 0) return;

        isDragging = true;
        originalPosition = transform.position;

        // Pause movement while dragging
        if (modelMover != null)
            modelMover.enabled = false;

        // Offset calculation for smooth drag
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorld.x, mouseWorld.y, 0);

        AudioManager.instance.PlayClick();
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = new Vector3(mouseWorld.x, mouseWorld.y, 0) + offset;
        transform.position = new Vector3(targetPos.x, targetPos.y, originalPosition.z);
    }

    void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        // Detect nearby model to possibly swap with
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.3f);

        if (hit != null && hit.transform != transform && Tags.Contains(hit.gameObject.tag))
        {
            float distance = Vector3.Distance(originalPosition, hit.transform.position);

            if (distance <= swapDistance)
            {
                // Perform swap
                Vector3 temp = hit.transform.position;
                hit.transform.position = originalPosition;
                transform.position = temp;

                AudioManager.instance.PlaySwish();

                // Resume movement for both
                ResumeMovement();
                hit.GetComponent<DragAndDropMoving>()?.ResumeMovement();
                return;
            }
            else
            {
                AudioManager.instance.PlayError(); // Too far to swap
            }
        }

        // If no valid swap, return to original position
        transform.position = originalPosition;
        ResumeMovement();
    }

    private void ResumeMovement()
    {
        if (modelMover != null)
            modelMover.enabled = true;
    }
}

