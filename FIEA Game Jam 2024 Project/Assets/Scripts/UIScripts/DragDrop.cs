using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : ShopHandling, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public RectTransform rectTransform;
    public Canvas canvas;
    private CanvasGroup canvasGroup;
    public GameObject prefabToInstantiate;
    private DragDropManager dragDropManager;
    private ShopHandling shopHandling;
    public int cost;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        dragDropManager = FindObjectOfType<DragDropManager>();
        shopHandling = FindObjectOfType<ShopHandling>();
        //Check if it is above holder, then snap
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        // If on screen, drop it, use money (set only taking money once), and put a new instance of ui in holder
        if(dragDropManager != null && !dragDropManager.draggedSprites.Contains(this))
        {
            dragDropManager.draggedSprites.Add(this);

            // Get the index of the spot in the UIHolder array based on the position
            int spotIndex = GetSpotIndex(rectTransform.position);

            // Instantiate a new UI sprite in the same spot
            if (spotIndex != -1)
            {
                shopHandling.InstantiateNewUISprite(spotIndex);
            }
        }

        // If on holder, put back

        // If on trash, refund
    }
    private int GetSpotIndex(Vector3 position)
    {
        // Check the position against the positions of UI holders and return the corresponding index
        for (int i = 0; i < UIHolder.Length; i++)
        {
            float threshold = 50f / canvas.scaleFactor; // Adjust threshold based on Canvas's scale factor
            if (Vector3.Distance(position, UIHolder[i].transform.position) < threshold)
            {
                return i;
            }
        }
        return -1; // Return -1 if no spot is found
    }

    public void InstantiatePrefabAtPoint(Vector3 pos)
    {
        Instantiate(prefabToInstantiate, pos, Quaternion.identity);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
