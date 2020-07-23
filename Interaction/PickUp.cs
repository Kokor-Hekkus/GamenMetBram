using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public Item item;


    public void Interact()
    {
        Debug.Log("DIT WERKT GEWOON GODVERDOMME");
    }
}
