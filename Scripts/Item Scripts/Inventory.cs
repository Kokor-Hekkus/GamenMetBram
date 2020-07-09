﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   

    #region inventoryinstance
    public static Inventory instance;

    private void Awake()
    {
        if (instance = null)
        {
            Debug.LogWarning("Meer dan 1 instance van inventory");
            return;
        }
        instance = this;
    }

    #endregion

    public List<Item> items = new List<Item>();
    public void Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            items.Add(item);
        }
        
    }

    public void Remove (Item item)
    {
        items.Remove(item);
    }
}
