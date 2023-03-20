using System;
using UnityEngine;
	public class Dagger_Attack : Attack
	{
		public double Attack(Weapons dagger)
		{
			return dagger.Damage;
		}
		public Dagger_Attack()
		{
		}
	}

