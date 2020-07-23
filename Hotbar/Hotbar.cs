using UnityEngine;



    public class Hotbar : MonoBehaviour
    {
        [SerializeField] private HotbarSlot[] hotbarSlots = new HotbarSlot[10];

        public void Add(Item itemToAdd) //we have this so that when we use a schortcut (for example) this can still check if the item can be added to the slot. Which isn't necessary when just dragging
        {
            foreach(HotbarSlot hotbarSlot in hotbarSlots)
            {
                if(hotbarSlot.AddItem(itemToAdd))
                {
                    return;
                }
            }
        }
        //Add saving/loading 
    }
