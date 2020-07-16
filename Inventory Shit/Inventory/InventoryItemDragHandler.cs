using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectMarc
{
    public class InventoryItemDragHandler : ItemDragHandler
    {
        [SerializeField] private ItemDestroyer itemDestroyer = null;
        private bool onMouseOver;

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left /*&& onMouseOver == true*/)
            {

                // InventorySlot thisSlot = ItemSlotUI as InventorySlot;
               // itemDestroyer.Destroy(thisSlot.ItemSlot, thisSlot.SlotIndex);

                base.OnPointerUp(eventData); //on release and not hovering on anything --> destroy/drop item
                if (eventData.hovered.Count == 0)
                {
                    InventorySlot thisSlot = ItemSlotUI as InventorySlot;
                    itemDestroyer.Activate(thisSlot.ItemSlot, thisSlot.SlotIndex);
                    


                   // test voor 'prullenbak'
                    //if(Input.mousePosition == )  //chekcen met locatie van trashcan. dan itemDestroyer.Destroy(thisSlot.ItemSlot, thisSlot.SlotIndex) en dan mag activate weg. Dat is alleen om de pop-up te activeren 
                    //{

                    //}
                    
                     
                }

            }

        }
       /* void OnMouseOver()
        {
            onMouseOver = true;
        }

        private void OnMouseExit()
        {
            onMouseOver = false;
        }*/

    }
}