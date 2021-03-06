﻿using UnityEngine;


    public abstract class Item : ScriptableObject
    {

        [Header("Basic Info")]
        [SerializeField] private new string name = "New Item";
        [SerializeField] private Sprite icon = null;

        public bool isDefaultItem = false;

        public string Name => name;
        public abstract string ColouredName { get; }
        public Sprite Icon => icon;
        public abstract string GetInfoDisplayText();




        //[SerializeField] public bool pickUp = true;

    
    }
