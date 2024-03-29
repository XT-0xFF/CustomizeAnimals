﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace CustomizeAnimals.Settings
{
	internal class SettingPredator : BaseSetting<bool>
	{
		#region CONSTRUCTORS
		public SettingPredator(ThingDef animal, bool isGlobal = false) : base(animal, isGlobal)
		{ }
		#endregion

		#region INTERFACES
		public override void GetValue()
		{
			var race = Animal?.race;
			if (race != null)
				Value = race.predator;
			else if (!IsGlobal)
				Log.Warning($"{nameof(CustomizeAnimals)}.{nameof(SettingPredator)}: {Animal?.defName} race is null, value cannot be set!");
		}
		public override void SetValue()
		{
			var race = Animal?.race;
			if (race != null)
				race.predator = Value;
		}

		public override void ExposeData()
		{
			var value = Value;
			Scribe_Values.Look(ref value, "Predator", DefaultValue);
			Value = value;
		}
		#endregion
	}
}
