using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour, IItemContainer
{
    [SerializeField] private int inventorySize;
    private void Start()
    {
        inventory.SetSize(inventorySize);
    }


    [SerializeField] private Inventory inventory = null;

    public ItemSlot AddItem(ItemSlot itemSlot) => inventory.AddItem(itemSlot);

    public int GetTotalQuantity(InventoryItem item) => inventory.GetTotalQuantity(item);

    public bool HasItem(InventoryItem item) => inventory.HasItem(item);

    public void RemoveAt(int slotIndex) => inventory.RemoveAt(slotIndex);

    public void RemoveItem(ItemSlot itemSlot) => inventory.RemoveItem(itemSlot);

    public void Swap(int indexOne, int indexTwo) => inventory.Swap(indexOne, indexTwo);
}
