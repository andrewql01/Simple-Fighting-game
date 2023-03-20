using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
public class FightScripts : MonoBehaviour
{
	public class Fight
	{
		public ContenderScripts.Contender Contender { get; set; }
		public Fight(ContenderScripts.Contender contender)
		{
			Contender = contender;
		}

	}
	public Fight NewFight;
	GameObject bowBtn;
	GameObject swordBtn;
	GameObject daggerBtn;
	ContenderScripts.Contender contender;
	void Start()
    {
		bowBtn = GameObject.Find("BowAttack");
		swordBtn = GameObject.Find("SwordAttack");
		daggerBtn = GameObject.Find("DaggerAttack");
		SetupContender();
		NewFight = new Fight(contender);
	}
	public void ExchangeAttacks(Button btn)
	{
		if (btn.GetComponent<Button>().name.Contains("Bow") == true)
		{
			PlayerScripts.player.AttackTransition(new Bow_Attack());
			NewFight.Contender.DamageTaken = PlayerScripts.player.attack.Attack(PlayerScripts.player.CurrentWeapons[0]);
		}
		else if (btn.GetComponent<Button>().name.Contains("Sword") == true)
		{
			PlayerScripts.player.AttackTransition(new Sword_Attack());
			NewFight.Contender.DamageTaken = PlayerScripts.player.attack.Attack(PlayerScripts.player.CurrentWeapons[1]);
		}
		else if (btn.GetComponent<Button>().name.Contains("Dagger"))
		{
			PlayerScripts.player.AttackTransition(new Dagger_Attack());
			NewFight.Contender.DamageTaken = PlayerScripts.player.attack.Attack(PlayerScripts.player.CurrentWeapons[2]);
		}
		PlayerScripts.player.DamageTaken = NewFight.Contender.attack.Attack(NewFight.Contender.CurrentWeapons[0]);
	}
	public void DefendYourself(Button btn)
	{
		if (btn.GetComponent<Button>().name.Contains("Dodge") == true)
		{
			PlayerScripts.player.DefenceTransition(new Defence_Dodge());
			PlayerScripts.player.DamageTaken = NewFight.Contender.attack.Attack(NewFight.Contender.CurrentWeapons[0]);
		}
		else if (btn.GetComponent<Button>().name.Contains("Block") == true)
		{
			PlayerScripts.player.DefenceTransition(new Defence_Block());
			PlayerScripts.player.DamageTaken = 0;
		}
	}
	void CheckPossibleAttacks()
	{
		int bowCount = PlayerScripts.player.ListOfWeapons.Where(x => x is Bow).Count();
		int swordCount = PlayerScripts.player.ListOfWeapons.Where(x => x is Sword).Count();
		int daggerCount = PlayerScripts.player.ListOfWeapons.Where(x => x is Dagger).Count();
		if (bowCount != 0)
		{
			bowBtn.SetActive(true);
		}
		else
		{
			bowBtn.SetActive(false);
		}
		if (swordCount != 0)
		{
			swordBtn.SetActive(true);
		}
		else
		{
			swordBtn.SetActive(false);
		}
		if (daggerCount != 0)
		{
			daggerBtn.SetActive(true);
		}
		else
		{
			daggerBtn.SetActive(false);
		}
	}
	void SetupContender()
	{
        System.Random random = new System.Random();
		Sword sword = new(random.Next(PlayerScripts.player.Level * 2, PlayerScripts.player.Level * 5), random.Next(1, PlayerScripts.player.Level * 2), "Bad Edge", "Sword",1);
		contender = new ContenderScripts.Contender(sword);
		contender.AttackTransition(new Sword_Attack());
	}
	void DisplayHealth()
	{
		TextMeshProUGUI HealthText2 = GameObject.Find("HealthText2").GetComponent<TextMeshProUGUI>();
		HealthText2.text = "Health: " + contender.Health;
		TextMeshProUGUI HealthText1 = GameObject.Find("HealthText1").GetComponent<TextMeshProUGUI>();
		HealthText1.text = "Health: " + PlayerScripts.player.Health;
	}
    void Update()
    {
		if (NewFight.Contender.Health <= 0 || PlayerScripts.player.Health <= 0)
		{
			if (PlayerScripts.player.Health > 0)
			{
				PlayerScripts.player.Level += 1;
				EditorUtility.DisplayDialog("Wygrales!", "Twoj lvl to:" + PlayerScripts.player.Level, "ok");
			}
			else
			{
				PlayerScripts.player.Level = 1;
				EditorUtility.DisplayDialog("Przegrales!", "Twoj lvl to:" + PlayerScripts.player.Level, "ok");
			}
			
			PlayerScripts.player.Health = 100;
			SetupContender();
			ShopScripts.coins += 10;
			NewFight = new Fight(contender);
			SceneManager.LoadScene(0, LoadSceneMode.Single);
			
		}
		CheckPossibleAttacks();
		DisplayHealth();
    }


}
	


