using UnityEngine;


    public class ItemDestroyer : MonoBehaviour
    {
        [SerializeField] private Inventory inventory = null;
     


        public void Destroy(int slotIndex)
        {
            inventory.RemoveAt(slotIndex);

            
        }
    }
