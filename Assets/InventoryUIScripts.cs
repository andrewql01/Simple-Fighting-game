using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIScripts : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlotScripts[] slots;
    InventoryScripts inventory;
    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        inventory = InventoryScripts.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlotScripts>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                slots[i].GetComponent<Image>().enabled = true;

            }
            else
            {
                slots[i].ClearSlot();
                slots[i].GetComponent<Image>().enabled = false;
               
            }
        }
    }
    public void InteractWithInventory()
    {
         inventoryUI.SetActive(!inventoryUI.activeSelf);

    }
}
