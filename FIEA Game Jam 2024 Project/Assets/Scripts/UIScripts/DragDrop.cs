using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : ShopHandling, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public RectTransform rectTransform;
    public Canvas canvas;
    private CanvasGroup canvasGroup;
    public GameObject prefabToInstantiate;
    private DragDropManager dragDropManager;
    private GameObject shopHandlerObj;
    private ShopHandling shopHandling;
    private GameObject updateMoneyObj;
    private UpdateMoney updateMoney;
    Vector2 originalPos;
    public int cost;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        dragDropManager = FindObjectOfType<DragDropManager>();
        shopHandlerObj = GameObject.Find("LevelBuilder");
        shopHandling = shopHandlerObj.GetComponent<ShopHandling>();
        originalPos = gameObject.transform.position;
        updateMoneyObj = GameObject.Find("Money");
        updateMoney = updateMoneyObj.GetComponent<UpdateMoney>();
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
            shopHandling.InstantiateUIElement(GetObjectIndexByName(gameObject.name), originalPos);
            shopHandling.moneySpent += cost;
            updateMoney.UpdateUIText(shopHandling.moneySpent);
        }
    }

    public void InstantiatePrefabAtPoint(Vector3 pos)
    {
        Instantiate(prefabToInstantiate, pos, Quaternion.identity);
    }
}
