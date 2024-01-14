using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashHandler : ShopHandling, IDropHandler
{
    private GameObject shopHandlerObj;
    private ShopHandling shopHandling;
    private GameObject updateMoneyObj;
    private UpdateMoney updateMoney;

    private void Start()
    {
        shopHandlerObj = GameObject.Find("LevelBuilder");
        shopHandling = shopHandlerObj.GetComponent<ShopHandling>();
        updateMoneyObj = GameObject.Find("Money");
        updateMoney = updateMoneyObj.GetComponent<UpdateMoney>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // Destroy object held
            Destroy(eventData.pointerDrag);
            // Refund
            shopHandling.moneySpent -= eventData.pointerDrag.GetComponent<DragDrop>().cost;
            updateMoney.UpdateUIText(shopHandling.moneySpent);
        }
    }
}
