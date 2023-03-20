using System;
using System.Collections.Generic;
using UnityEngine;
interface IEquipement
{
	List<Weapons> CurrentWeapons { get; set; }
	List<Weapons> ListOfWeapons { get; set; }
	List<Armor> EquippedArmor { get; set; }
}

