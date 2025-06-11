using System.Collections.Generic;
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
        if (timerScript != null && timerScript.timer <= 0) return;

        Time.timeScale = 0;
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
    }

    void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;
        Time.timeScale = 1;

        // Check for overlapping object
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.3f);
        if (hit != null && hit.transform != transform && Tags.Contains(hit.gameObject.tag))
        {
            float distance = Vector3.Distance(originalPosition, hit.transform.position);

            if (distance <= swapDistance)
            {
                // Swap positions
                Vector3 tempPos = hit.transform.position;
                hit.transform.position = originalPosition;
                transform.position = tempPos;

                AudioManager.instance.PlaySwish(); // successful swap
                // Optionally call win-check logic here
                // GameManager.Instance.CheckForWin();
            }
            else
            {
                // Too far to swap
                AudioManager.instance.PlayError();
                transform.position = originalPosition;
            }
        }
        else
        {
            // Not a valid target or not overlapping
            transform.position = originalPosition;
        }
    }
}

