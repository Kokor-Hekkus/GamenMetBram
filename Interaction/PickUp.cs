using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
   // public Item item;
    [SerializeField] private ItemSlot itemSlot;

    public void Interact(GameObject other)
    {
        Debug.Log("DIT WERKT GEWOON GODVERDOMME");

        IItemContainer itemContainer = other.GetComponent<IItemContainer>();

       if(itemContainer.AddItem(itemSlot).quantity == 0)
        {
            Destroy(gameObject);
        }
    }
}
