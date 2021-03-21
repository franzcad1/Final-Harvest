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
public class PrefabTimedSpawner : MonoBehaviour
{

    // Spawn rate
    [SerializeField]
    private float spawnRatePerMinute = 30;
    // Current spawn count
    private int currentCount = 0;
    // Reference to used factory
    [SerializeField]
    private GenericFactory factory;
    /// <summary>
    /// Unity's method called every frame
    /// </summary>
    private void Update()
    {
        var targetCount = Time.time * (spawnRatePerMinute / 60);
        while (targetCount > currentCount)
        {
            var inst = factory.GetNewInstance();
            inst.transform.position = new Vector3(Random.Range(-15.0f, 50.0f), 3, Random.Range(-7.0f, 17.0f));
            currentCount++;
        }
    }
}
