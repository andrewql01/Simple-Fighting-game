using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ContenderScripts : MonoBehaviour
{
	public class Contender : IEntityStats
	{
		public Attack attack;
		public void AttackTransition(Attack a)
		{
			attack = a;
		}
		public List<Weapons> CurrentWeapons { get; set; }
		private double strength;
		private double health;
		private int level;
		public int Level { get { return level; } set { level = value; } }
		public double Strength { get { return strength; } set { strength = value+(level*4); } }
		public double Health { get { return health; } set { health = value+(level * 10); } }
		public double DamageTaken { get {return health; } set { health -= value; } }
		public Contender(Weapons w)
		{
            System.Random random = new System.Random();
			Strength = PlayerScripts.player.Strength + random.Next(-5,5);
			Health = PlayerScripts.player.Level*random.Next(0,5)*5+100;
			Level = PlayerScripts.player.Level+random.Next(0,2);
			CurrentWeapons = new List<Weapons>();
			CurrentWeapons.Add(w);
		}
	}
}


