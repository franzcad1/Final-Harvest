using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 04/05/21
 */
public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int StartXPosition;
    public int StartYPosition;
    public int XBetweenItems;
    public int NumberOfColumns;
    public int YBetweenItems;
    public ItemObject DefaultWeapon;
    public ItemObject DefaultAmmo;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        inventory.AddItem(DefaultWeapon, 1);
        inventory.AddItem(DefaultAmmo, 25);
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void CreateDisplay()
    {
        
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
        
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(StartXPosition + (XBetweenItems * (i % NumberOfColumns)), StartYPosition + (-YBetweenItems * (i / NumberOfColumns)), 0f);
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
