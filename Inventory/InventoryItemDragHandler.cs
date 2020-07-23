using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


    public class InventoryItemDragHandler : ItemDragHandler
    {
        [SerializeField] private ItemDestroyer itemDestroyer = null;
      

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                

               

                base.OnPointerUp(eventData); 
                if (eventData.pointerCurrentRaycast.gameObject && eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemDestroyer>()) 
                {
                    itemDestroyer = eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemDestroyer>();
                    InventorySlot thisSlot = ItemSlotUI as InventorySlot;
                    itemDestroyer.Destroy(thisSlot.SlotIndex);
                    


                   
                    
                     
                }

            }

        }
       
    }
