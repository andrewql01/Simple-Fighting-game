using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryScripts : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public static InventoryScripts instance;
    private void Awake()
    {
        instance = this;
    }
    public List<ItemScripts> items = new List<ItemScripts>();
    public void Buy()
    {
        foreach (var i in PlayerScripts.player.ListOfWeapons)
        {
            var item = OtherInventoryScripts.instance.weaponsBuy.Where(x => x.id == i.Id).First();
            if(item!=null && InventoryScripts.instance.items.Contains(item)==false)
                InventoryScripts.instance.items.Add(item);
        }
        if (PlayerScripts.player.AvailiblePotion != null)
        {
            var potion1 = OtherInventoryScripts.instance.weaponsBuy.Where(x => x.id == 11).First();
            var potion2 = OtherInventoryScripts.instance.weaponsBuy.Where(x => x.id == 12).First();
            if (PlayerScripts.player.AvailiblePotion.Id == 11 && InventoryScripts.instance.items.Contains(potion1) == false)
            {
                if (InventoryScripts.instance.items.Contains(potion2))
                {
                    InventoryScripts.instance.items.Remove(potion2);
                }
                InventoryScripts.instance.items.Add(potion1);

            }
            else if (PlayerScripts.player.AvailiblePotion.Id == 12 && InventoryScripts.instance.items.Contains(potion2) == false)
            {
                if (InventoryScripts.instance.items.Contains(potion1))
                {
                    InventoryScripts.instance.items.Remove(potion1);
                }
                InventoryScripts.instance.items.Add(potion2);
            }

        }
        else
        {
            var potion1 = OtherInventoryScripts.instance.weaponsBuy.Where(x => x.id == 11).First();
            var potion2 = OtherInventoryScripts.instance.weaponsBuy.Where(x => x.id == 12).First();
            InventoryScripts.instance.items.Remove(potion1);
            InventoryScripts.instance.items.Remove(potion2);
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        
    }
    private void Update()
    {
        Buy();
    }
}
