using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelRouteSpot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObj = eventData.pointerDrag;

        if (draggedObj != null)
        {
            DragandDrop draggedModel = draggedObj.GetComponent<DragandDrop>();

            if (draggedModel != null)
            {
                Transform oldModel = transform.childCount > 0 ? transform.GetChild(0) : null;

                // Swap models if another is present
                if (oldModel != null)
                {
                    // Move old model back to where dragged came from
                    //oldModel.SetParent(draggedModel.);
                    oldModel.position = draggedModel.originalPosition;
                }

                // Snap dragged model to this route spot
                draggedModel.transform.SetParent(transform);
                draggedModel.transform.position = transform.position;

                AudioManager.instance.PlaySwish();
            }
        }
    }
}
