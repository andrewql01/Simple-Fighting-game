using System;
using UnityEngine;
public class ArmorPants : Armor
{
	private double armor;
	private string name;
	private string description;
	private int id;
	public int Id { get { return id; } set { id = value; } }
	public double Armor { get { return armor; } set { armor = value; } }
	public string Name { get { return name; } set { name = value; } }
	public string Description { get { return description; } set { description = value; } }

	public ArmorPants(double a,string n,string d,int i)
	{
		armor = a;
		name = n;
		description = d;
		Id = i;

	}
}

