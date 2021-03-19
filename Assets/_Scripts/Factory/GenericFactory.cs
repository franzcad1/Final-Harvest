using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
/// <summary>
/// Factory design pattern.
/// </summary>
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