using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 04/14/21
 */

public class Acheivement : MonoBehaviour
{
    public GameObject Achievement;

 void OnTriggerEnter(Collider other)
    {
        Achievement.SetActive(true);
    }
}
