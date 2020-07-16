using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ProjectMarc
{
    [CreateAssetMenu(fileName ="New Inventory", menuName ="Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
        [SerializeField] private ItemSlot testItemSlot = new ItemSlot();

        public ItemContainer ItemContainer { get; } = new ItemContainer(24);

        public void OnEnable()
        {
            ItemContainer.OnItemsUpdated += onInventoryItemsUpdated.Raise;
        }

        public void OnDisable()
        {
            ItemContainer.OnItemsUpdated -= onInventoryItemsUpdated.Raise;
        }

        [ContextMenu("Test Add Item")]
        public void TestAdd()
        {
            ItemContainer.AddItem(testItemSlot);
        }

      
    }

   

}