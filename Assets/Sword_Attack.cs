using System;
using UnityEngine;

	public class Sword_Attack : Attack
	{
		public double Attack(Weapons sword)
		{
			return sword.Damage;
		}
		public Sword_Attack()
		{

		}
	}


