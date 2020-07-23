using UnityEngine.EventSystems;


    public class HotbarItemDragHandler : ItemDragHandler
    {
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)//if we realease the leftmousebutton on a hotbarslot (while dragging hotbarslot), do the following
            {

                base.OnPointerUp(eventData);
                if (eventData.hovered.Count == 0)
                {
                    (itemSlotUI as HotbarSlot).SlotItem = null; //when we realease and release over nothing then clear the slot 
                    //CHANGE TO TRASHCAN FUNCTIONALITY
                }
            }
            
        }
    }
