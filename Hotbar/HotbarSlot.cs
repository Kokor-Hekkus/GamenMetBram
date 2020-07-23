using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


    public class HotbarSlot : ItemSlotUI, IDropHandler
    {

        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI itemQuantityText = null;

        private Item slotItem = null;

        public override Item SlotItem
        {
            get 
            { 
                return slotItem; 
            }
            set 
            { 
                slotItem = value; 
                UpdateSlotUI(); 
            }
        }

        public bool AddItem(Item itemToAdd)
        {
            if (SlotItem != null)
            {
                return false;
            }
            SlotItem = itemToAdd;
            return true;
        }

        public void UseSlot(int index)
        {
            if (index != SlotIndex) //when pressing a key -- tell each slot that they are being used, using index makes sure we only use the correct one!
            {
                return;
                //use item
            }
           
        }

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();   //making sure that the dropped thing is an itemdraghandler
            if (itemDragHandler == null) //if it isn't -- return
            {
                return;
            }

            InventorySlot inventorySlot = itemDragHandler.ItemSlotUI as InventorySlot; //treat it like an inventoryslot
            if (inventorySlot != null) //if it is, do the following
            {
                SlotItem = inventorySlot.ItemSlot.item;
                return; //get the item from that slot, set it and then return
            }

            HotbarSlot hotbarSlot = itemDragHandler.ItemSlotUI as HotbarSlot;
            if (hotbarSlot != null) //if it's a hotbarlsot swap the two
            {
                Item oldItem = SlotItem;
                SlotItem = hotbarSlot.SlotItem;
                hotbarSlot.SlotItem = oldItem;
                return;
            }

        }

        public override void UpdateSlotUI()
        {
            if (SlotItem == null) //if there's nothing in this slot disable the slotui
            {
                EnableSlotUI(false);
                return;
            }

            itemIconImage.sprite = SlotItem.Icon;
            EnableSlotUI(true);
            SetItemQuantityUI();
        }

        private void SetItemQuantityUI() //does this thing have a quantity and if so set it
        {
            if (SlotItem is InventoryItem inventoryItem)
            {
                if (inventory.HasItem(inventoryItem)) //check if the player still has the item, if they do then do the following
                {
                    int quantityCount = inventory.GetTotalQuantity(inventoryItem); //get the total of how many of this item we have
                    itemQuantityText.text = quantityCount > 1 ? quantityCount.ToString() : ""; //this check to see if the quantitycount is greater than 1. If so set it to the itemquantity, otherwise leave it blank
                }
                else
                {
                    SlotItem = null;
                }
            }
            else
            {
                itemQuantityText.enabled = false; //if it's not an inventory item the text is disabled
            }
        }

        protected override void EnableSlotUI(bool enable)
        {
            base.EnableSlotUI(enable);
            itemQuantityText.enabled = enable;
        }
    }

