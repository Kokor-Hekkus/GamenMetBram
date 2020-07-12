using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    Item item;
    public Image icon;
  


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            UseItem();
        else if (eventData.button == PointerEventData.InputButton.Middle)
            Debug.Log("Middle click");
        else if (eventData.button == PointerEventData.InputButton.Right)
            DropItem();
    }

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }


   /* public void ItemClicked(PointerEventData eventData)

    {
       if (eventData.button == PointerEventData.InputButton.Left)
        {
            UseItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            DropItem();
        }
    }*/

    void DropItem()
    {
        if (item != null)
        {
            Debug.Log("BE GONE FOOL");
            Inventory.instance.Remove(item);

        }
    }

    void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }

    }
}
