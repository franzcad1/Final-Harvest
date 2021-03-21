using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 03/21/21
 */
public class GenericFactory : MonoBehaviour
{
    // Reference to prefab.
    [SerializeField]
    private GameObject prefab;
    /// <summary>
    /// Creating new instance of prefab.
    /// </summary>
    /// <returns>New instance of prefab.</returns>
    public GameObject GetNewInstance()
    {
        return Instantiate(prefab);
    }
}