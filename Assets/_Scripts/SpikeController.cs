using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
