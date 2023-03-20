using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopScripts : MonoBehaviour
{
    public int[,] weapons = new int[4, 7];
    public List<Weapons> weaponsToBuy = new List<Weapons>();
    public List<Armor> armorsToBuy = new List<Armor>();
    public List<Potion> potionsToBuy = new List<Potion>();
    public int[,] armors = new int[4, 5];
    public int[,] potions = new int[4, 3];
    public static float coins;
    public TextMeshProUGUI CoinsText;
    public Transform content1;
    public Transform content2;
    public Transform content3;
    public Transform PotionsParent;
    public List<ItemScripts> weaponsBuy;
    public List<ItemScripts> potionsBuy;
    public List<ItemScripts> armorBuy;
    public void ShowIcons()
    {
        for (int i = 0; i < content1.childCount; i++)
        {
            content1.GetChild(i).GetComponent<Image>().sprite = weaponsBuy[i].icon;
        }
        for (int i = 0; i < content2.childCount; i++)
        {
            content2.GetChild(i).GetComponent<Image>().sprite = armorBuy[i].icon;
        }
        for (int i = 0; i < content3.childCount; i++)
        {
            content3.GetChild(i).GetComponent<Image>().sprite = potionsBuy[i].icon;
        }

    }
    public void BuyPotions()
    {
        GameObject btnClicked = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (coins >= potions[2, btnClicked.GetComponent<ButtonInfo>().ItemID-10])
        {
            coins -= potions[2, btnClicked.GetComponent<ButtonInfo>().ItemID-10];
            CoinsText.text = "Coins: " + coins.ToString();
            PlayerScripts.player.AvailiblePotion = potionsToBuy[btnClicked.GetComponent<ButtonInfo>().ItemID - 11];
        }
        
    }
    public void BuyWeapon()
    {
        
        GameObject btnClicked = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (coins >= weapons[2, btnClicked.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= weapons[2, btnClicked.GetComponent<ButtonInfo>().ItemID];
            CoinsText.text = "Coins: " + coins.ToString();
            PlayerScripts.player.ListOfWeapons.Add(weaponsToBuy[btnClicked.GetComponent<ButtonInfo>().ItemID-1]);
            var itemadd = weaponsToBuy[btnClicked.GetComponent<ButtonInfo>().ItemID - 1];
            if (itemadd is Bow)
            {
                if (PlayerScripts.player.CurrentWeapons[0] == null)
                {
                    PlayerScripts.player.CurrentWeapons[0]=itemadd;
                }
            }
            else if (itemadd is Dagger)
            {
                if (PlayerScripts.player.CurrentWeapons[2] == null)
                {
                    PlayerScripts.player.CurrentWeapons[2] = itemadd;
                }
            }
            else if (itemadd is Sword)
            {
                if (PlayerScripts.player.CurrentWeapons[1] == null)
                {
                    PlayerScripts.player.CurrentWeapons[1] = itemadd;
                }
            }
            btnClicked.GetComponent<Button>().interactable = false;
        }

    }
    public void BuyArmor()
    {
        GameObject btnClicked = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (coins >= armors[2, btnClicked.GetComponent<ButtonInfo>().ItemID-6])
        {
            coins -= armors[2, btnClicked.GetComponent<ButtonInfo>().ItemID-6];
            CoinsText.text = "Coins: " + coins.ToString();
            var ArmorPart = armorsToBuy[btnClicked.GetComponent<ButtonInfo>().ItemID - 7];
            if (ArmorPart.Name.Contains("Chest"))
            {
                PlayerScripts.player.EquippedArmor[0] = ArmorPart;
            }
            else if (ArmorPart.Name.Contains("Pants"))
            {
                PlayerScripts.player.EquippedArmor[1] = ArmorPart;
            }
            btnClicked.GetComponent<Button>().interactable = false;
        }

    }
    void Start()
    {

        if (PlayerScripts.player.Level == 1)
        {
            coins = 100;
        }

        CoinsText.text = "Coins:" + coins.ToString();

        weaponsToBuy.Add(new Bow(10, 3, "Great Bow","",1));
        weaponsToBuy.Add(new Bow(12, 3, "Meow Bow","", 2));
        weaponsToBuy.Add(new Dagger(15, 3, "Blue Dagger","", 3));
        weaponsToBuy.Add(new Dagger(24, 3, "Great Dagger","", 4));
        weaponsToBuy.Add(new Sword(30, 3,  "Huge Sword","", 5));
        weaponsToBuy.Add(new Sword(30, 30, "5.0 Sword","", 6));
        armorsToBuy.Add(new ChestPlate(10,"Classic Chest Plate","",1));
        armorsToBuy.Add(new ChestPlate(40, "Diamond Chest Plate", "",2));
        armorsToBuy.Add(new ArmorPants(10, "Classic Armored Pants", "",3));
        armorsToBuy.Add(new ArmorPants(30, "Diamond Pants", "",4));
        potionsToBuy.Add(new Potion(10,11));
        potionsToBuy.Add(new Potion(25,12));

        weapons[1, 1] = 1;
        weapons[1, 2] = 2;
        weapons[1, 3] = 3;
        weapons[1, 4] = 4;
        weapons[1, 5] = 5;
        weapons[1, 6] = 6;

        weapons[2, 1] = 10;
        weapons[2, 2] = 20;
        weapons[2, 3] = 30;
        weapons[2, 4] = 40;
        weapons[2, 5] = 50;
        weapons[2, 6] = 60;

        armors[1, 1] = 1;
        armors[1, 2] = 2;
        armors[1, 3] = 3;
        armors[1, 4] = 4;
    
        armors[2, 1] = 10;
        armors[2, 2] = 70;
        armors[2, 3] = 30;
        armors[2, 4] = 50;

        potions[1, 1] = 1;
        potions[1, 2] = 2;

        potions[2, 1] = 20;
        potions[2, 2] = 30;

        foreach (var i in PlayerScripts.player.ListOfWeapons)
        {
            if (i != null)
                content1.GetChild(i.Id-1).GetComponent<Button>().interactable = false;

        }
        foreach (var i in PlayerScripts.player.EquippedArmor)
        {
            if (i != null)
                content2.GetChild(i.Id- 1).GetComponent<Button>().interactable = false;
        }

        ShowIcons();

    }
    void Update()
    {
        if (PlayerScripts.player.AvailiblePotion != null)
        {
            for (int i = 0; i < PotionsParent.childCount; i++)
            {
                PotionsParent.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }

    }
}
