using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections.Generic;
public class PlayerScripts : MonoBehaviour
{
	public class Player : IEntityStats, IEquipement
	{
		public Attack attack = null;
		public Defence defence = null;
		public Healing healing = null;
		public void HealingTransition(Healing a)
		{
			healing = a;
		}
		public void DefenceTransition(Defence a)
		{
			defence = a;
		}
		public void AttackTransition(Attack a)
		{
			attack = a;
		}
		public Potion AvailiblePotion;
		public List<Weapons> CurrentWeapons { get; set; } = new List<Weapons>();
		public List<Weapons> ListOfWeapons { get; set; } = new List<Weapons>();
		public List<Armor> EquippedArmor { get; set; } = new List<Armor>();
		private double strength;
		private double health;
		private int level = 1;
		public int Level { get { return level; } set { level = value; } }
		public double Strength { get { return strength; } set { strength = value + (level * 4); } }
		public double Health { get { return health; } set { health = value + (level * 10); } }
		public double DamageTaken { get { return health; } set { health -= value; } }
		public double Heal { set { health = value + health; } }
		public Player(double s, double h, List<Weapons> c,List<Armor> a)
		{
			Strength = s;
			Health = h;
			CurrentWeapons = c;
			EquippedArmor = a;
		}
	}
	public static Player player { get; set; }

}


