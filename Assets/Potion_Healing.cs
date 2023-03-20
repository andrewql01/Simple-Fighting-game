using System;
using UnityEngine;
namespace FaceTheSword
{
	public class Potion_Healing : Healing
	{
		public double Heal(Potion a)
		{
			return a.effectiveHealing;
		}
		public Potion_Healing()
		{
		}
	}
}