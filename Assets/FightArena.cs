using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
	public class FightArena
	{
		public PlayerScripts.Player player;
		public ContenderScripts.Contender contender;
		public List<FightScripts.Fight> FightHistory = new List<FightScripts.Fight>();
		public void StartFight(FightScripts.Fight fight)
		{
			FightHistory.Add(fight);
		}
		public FightArena(PlayerScripts.Player p,ContenderScripts.Contender c)
		{
			player = p;
			contender = c;
		}
	}

