using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New DMGType", menuName = "Spells/DMGType")]
public class DamageType : ScriptableObject
{
    [SerializeField] private new string name = "New DMGType";
    [SerializeField] private Color color = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Element element;

    public string Name => name;

    public Color Color => color;

    public Element Element => element;
}
