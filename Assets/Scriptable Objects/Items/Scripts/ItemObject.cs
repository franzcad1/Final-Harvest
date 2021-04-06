using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 04/05/21
 */
public enum ItemType
{
    Default,
    Weapon,
    Heal
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
