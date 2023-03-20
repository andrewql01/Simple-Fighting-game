using System;
using UnityEngine;
public abstract class Weapons
{
	public double Damage { get; set; }
	public double CritChance { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public int Id;
	public Weapons(double d, double c, string n, string desc, int i)
	{
		Id = i;
		Damage = d;
		CritChance = c;
		Name = n;
		Description = desc;
	}
}


