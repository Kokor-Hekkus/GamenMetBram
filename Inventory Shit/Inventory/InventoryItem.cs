using UnityEngine;

namespace ProjectMarc
{
    public abstract class InventoryItem : Item
    {
        [Header("Item Data")]
        [SerializeField] [Min(0)] private int sellPrice = 1;
        [SerializeField] [Min(1)] private int maxStack = 1;

        public override string ColouredName => name;//is nog niet klaar
        public int SellPrice => sellPrice;
        public int MaxStack => maxStack;

    }
}