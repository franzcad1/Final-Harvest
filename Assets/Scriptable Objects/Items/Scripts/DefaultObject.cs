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

[CreateAssetMenu(fileName ="New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
   
}
