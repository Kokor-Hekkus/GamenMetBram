using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Spell : ScriptableObject, IHotbarItem
{

    [Header("Basic Info")]
    [SerializeField] private new string name = "New Spell";
    [SerializeField] private Sprite icon = null;
    [SerializeField] private Element element = null;

    public string Name => name;
    public Sprite Icon => Icon;
    public Element Element => element;


    public void Use()
    {
        Debug.Log($"Casting {Name}");
    }

 
}
