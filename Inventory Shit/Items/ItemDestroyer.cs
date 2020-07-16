using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectMarc
{
    public class ItemDestroyer : MonoBehaviour
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI sureText = null;

        private int slotIndex = 0;
        private void Start()
        {
            gameObject.SetActive(false);
        }


        private void OnDisable()
        {
            slotIndex = -1;
        }

        public void Activate(ItemSlot itemSlot, int slotIndex) 
        {
            this.slotIndex = slotIndex;
            sureText.text = $"Sure to destroy {itemSlot.item.ColouredName}?";
            gameObject.SetActive(true);
            Debug.Log("Active");
        }

        public void Destroy()
        {
            inventory.ItemContainer.RemoveAt(slotIndex);

            gameObject.SetActive(false);
        }
    }
}