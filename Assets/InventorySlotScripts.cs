using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotScripts : MonoBehaviour
{
    public Image icon;
    ItemScripts item;
    public void AddItem(ItemScripts newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
    public void UseItem()
    {
        if (item.id == 11 | item.id == 12)
        {
            PlayerScripts.player.Heal = PlayerScripts.player.AvailiblePotion.effectiveHealing;
            PlayerScripts.player.AvailiblePotion = null;
        }
        else
        {
            var weapon = PlayerScripts.player.ListOfWeapons.Where(x => x.Id == item.id).First();
            if (weapon is Bow)
            {
                PlayerScripts.player.CurrentWeapons[0] = weapon;
            }
            else if (weapon is Sword)
            {
                PlayerScripts.player.CurrentWeapons[1] = weapon;
            }
            else if (weapon is Dagger)
            {
                PlayerScripts.player.CurrentWeapons[2] = weapon;
            }
        }

    }
}
