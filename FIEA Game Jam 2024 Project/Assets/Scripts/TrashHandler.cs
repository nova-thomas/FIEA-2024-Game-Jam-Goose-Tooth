using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // Destroy object held
            Destroy(eventData.pointerDrag);
            // Refund
        }
    }
}
