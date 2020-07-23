using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Element", menuName = "Spells/Element")]
public class Element : ScriptableObject
{
    [SerializeField] private new string name = "New Element";
    [SerializeField] private Color color = new Color(1f, 1f, 1f, 1f);

    public string Name => name;

    public Color Color => color;
}
