using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ToggleInventoryWithKeyPress : MonoBehaviour
    {
        [SerializeField] private GameObject objectToToggle = null;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                objectToToggle.SetActive(!objectToToggle.activeSelf);
            }
        }
    }


