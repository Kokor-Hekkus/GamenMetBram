using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerInteraction : MonoBehaviour
    {
       public GameObject currentPuObject = null;
       private PickUp pickUp = null;


        void Update()
        {
            CheckForPu();
        }

        private void CheckForPu()
        {
            if (Input.GetMouseButtonDown(0) && currentPuObject)
            {
                pickUp.Interact();

            }
        }


        private void OnTriggerEnter2D(Collider2D puCollision) 
        {

            if (puCollision.GetComponent<PickUp>()) //check to see if collider is a pickup, if so add as our current interactable object
            {
                Debug.Log("OIOIOI");
                currentPuObject = puCollision.gameObject;
                pickUp = puCollision.GetComponent<PickUp>();
            }

        }

        private void OnTriggerExit2D(Collider2D exitCollision)
        {
            if (exitCollision.GetComponent<PickUp>() && exitCollision.gameObject == currentPuObject) //als collider een pickup is en onze huidige puobject en we verlaten de range
            {
                currentPuObject = null;
                pickUp = null;
            }
        }
      
    }
