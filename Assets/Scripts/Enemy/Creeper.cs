using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : MonoBehaviour
{
    private HealthBarScreenSpaceController playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("HealthBar-ScreenSpace").GetComponent<HealthBarScreenSpaceController>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(10);
            Debug.Log("I Collided with player");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(10);
            Debug.Log("I Collided with player");
        }
    }

}
