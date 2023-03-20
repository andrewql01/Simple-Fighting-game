using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMPro.TextMeshProUGUI Price;
    public GameObject ShopManager;
    private void Update()
    {

        if (ItemID >= 7 && ItemID < 11)
            Price.text = "Price: " + ShopManager.GetComponent<ShopScripts>().armors[2, ItemID-6].ToString();
        else if (ItemID >= 11 && ItemID < 13)
        {
            Price.text = "Price: " + ShopManager.GetComponent<ShopScripts>().potions[2, ItemID-10].ToString();
        } 
        else if (ItemID > 0 && ItemID < 7)
        {
            Price.text = "Price: " + ShopManager.GetComponent<ShopScripts>().weapons[2, ItemID].ToString();
        }
    }
}
