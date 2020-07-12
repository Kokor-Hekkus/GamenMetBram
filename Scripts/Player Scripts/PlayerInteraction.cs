using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentPuObject = null;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentPuObject)
        {
            PickUp(); //pick up item
        }
    }

    private void OnTriggerEnter2D(Collider2D puCollision) //check to see if collider is a pickup, if so add as our current interactable object
    {
        if (puCollision.GetComponent<Pickup>())
        {
            Debug.Log("OI");
            currentPuObject = puCollision.gameObject;
        }


    }

    private void OnTriggerExit2D(Collider2D exitCollision) //remove interactable object as interaction when leaving collider
    {
        if (exitCollision.GetComponent<Pickup>() && exitCollision.gameObject == currentPuObject)
        {
            currentPuObject = null;
        }

    }
    void PickUp()
    {

        bool wasPickedUp = Inventory.instance.Add(currentPuObject.GetComponent<Pickup>().item);
        if (wasPickedUp)
        {
            Destroy(currentPuObject);
        }
    }
}
