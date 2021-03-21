using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 03/21/21
 */
public class TimeoutObject : MonoBehaviour
{
    // Time after which object will be destroyed
    [SerializeField]
    private float timeout = 2;
    // Saving enable time to calculate when to destroy itself
    private float startTime;
    /// <summary>
    /// Unity's method called on object enable
    /// </summary>
    private void OnEnable()
    {
        startTime = Time.time;
    }
    /// <summary>
    /// Unity's method called every frame
    /// </summary>
    private void Update()
    {
        // Waiting for timeout
        if (Time.time - startTime > timeout)
        {
            // Destroying object
            Destroy(gameObject);
        }
    }
}
