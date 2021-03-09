using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 03/08/21
 */
public class SpikeController : MonoBehaviour
{

    public PlayerBehaviour playerBehaviour;
    public AudioSource hitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        hitSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerBehaviour.TakeDamage(50);
            hitSound.Play();
        }
    }

}
