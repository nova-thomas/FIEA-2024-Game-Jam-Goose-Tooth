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
    public int cost;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        dragDropManager = FindObjectOfType<DragDropManager>();
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
        if (dragDropManager != null && !dragDropManager.draggedSprites.Contains(this))
        {
            dragDropManager.draggedSprites.Add(this);
        }

        // If on holder, put back

        // If on trash, refund
    }

    public void InstantiatePrefabAtPoint(Vector3 pos)
    {
        Instantiate(prefabToInstantiate, pos, Quaternion.identity);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
