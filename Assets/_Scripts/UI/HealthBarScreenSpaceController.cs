using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 02/14/21
 */

[System.Serializable]
public class HealthBarScreenSpaceController : MonoBehaviour
{
    private Slider healthBarSlider;
    private Text healthText;

    [Range(0,100)]
    public int currentHealth = 100;
    [Range(1, 100)]
    public int maximumHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthBarSlider = GetComponent<Slider>();
        healthText = GetComponentInChildren<Text>();
        currentHealth = maximumHealth;
        healthText.text = currentHealth + "/100";
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth + "/100";

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int dmg)
    {
        healthBarSlider.value -= dmg;
        currentHealth -= dmg;

        if (currentHealth < 0)
        {
            healthBarSlider.value = 0;
            currentHealth = 0;
        }

        healthText.text = currentHealth + "/100";
    }
}
