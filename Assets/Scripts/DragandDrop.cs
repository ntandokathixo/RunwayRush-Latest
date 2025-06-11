using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    private Vector3 offset;
    public Vector3 originalPosition;
    public List<string> Tags;

    public TimerSystem timerScript;
    public float swapDistance = 1f;

    private bool isDragging = false;

    void OnMouseDown()
    {
        Time.timeScale = 0;
        if (timerScript != null && timerScript.timer <= 0) return;

        originalPosition = transform.position;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorld.x, mouseWorld.y, 0);
        isDragging = true;



        AudioManager.instance.PlayClick();
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = new Vector3(mouseWorld.x, mouseWorld.y, 0) + offset;
        transform.position = new Vector3(targetPos.x, targetPos.y, originalPosition.z);

        // Update indicator position

    }

    void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;
        Time.timeScale = 1;




        // Check if overlapping another model to swap
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.1f);
        if (hit != null && hit.transform != transform && Tags.Contains(hit.gameObject.tag))
        {
            float distance = Vector3.Distance(transform.position, hit.transform.position);
            if (distance <= swapDistance)
            {
                // Swap positions
                transform.position = hit.transform.position;
                hit.transform.position = originalPosition;
                AudioManager.instance.PlaySwish();
                return;
            }
            else
            {
                AudioManager.instance.PlayError(); // too far to swap
                transform.position = originalPosition;
            }
        }

        // If no valid swap, return to original position
        transform.position = originalPosition;

    }
}