using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


    public class InventorySlot : ItemSlotUI, IDropHandler
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI ItemQuantityText = null;

        public override Item SlotItem
        {
            get { return ItemSlot.item; }
            set { }

        }

        public ItemSlot ItemSlot => inventory.GetSlotByIndex(SlotIndex); //when referring to itemslot here it gets the correct item and not the whole array

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>(); //when something is dropped on this slot, try and get itemdraghandler script from teh thing that dropped
            if (itemDragHandler == null)
            {
                return;
            }
            if ((itemDragHandler.ItemSlotUI as InventorySlot) != null) //if it's an inventory slot that is dropped
            {
                inventory.Swap(itemDragHandler.ItemSlotUI.SlotIndex, SlotIndex); //swap index with current index
            }
        }

        public override void UpdateSlotUI()
        {
            if (ItemSlot.item == null)
            {
                EnableSlotUI(false);
                return;
            }

            EnableSlotUI(true);

            itemIconImage.sprite = ItemSlot.item.Icon;
            ItemQuantityText.text = ItemSlot.quantity > 1 ? ItemSlot.quantity.ToString() : ""; //if there's 1 or 0 items then set the quantity to blank, alse set it to the quantity (purely for the string)
        }

        protected override void EnableSlotUI(bool enable) //toggle the ui element for the slot on and off
        {
            base.EnableSlotUI(enable);
            ItemQuantityText.enabled = enable;
        }
    }
