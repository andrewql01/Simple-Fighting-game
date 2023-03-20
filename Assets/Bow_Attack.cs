using System;
using UnityEngine;
	public class Bow_Attack : Attack
	{
		public double Attack(Weapons bow)
		{
			return bow.Damage;
		}
		public Bow_Attack()
		{
		}
	}

