﻿using CustomizeAnimals.Settings;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace CustomizeAnimals.Controls
{
	internal class ControlGestationPeriodDays : BaseSettingControl
	{
		public override float CreateSetting(float offsetY, float viewWidth, AnimalSettings animalSettings)
		{
			if (!animalSettings.IsHumanLike)
			{
				var eggLayer = (SpecialSettingEggLayer)animalSettings.ReproductionSettings["EggLayer"];
				if (eggLayer.IsEggLayer)
					return 0f;
			}

			var setting = (BaseSetting<float>)animalSettings.ReproductionSettings["GestationPeriodDays"];
			var value = CreateNumeric(
				offsetY,
				viewWidth,
				"SY_CA.GestationPeriodDays".Translate(),
				"SY_CA.TooltipGestationPeriodDays".Translate(),
				setting.IsModified(),
				setting.Value,
				setting.DefaultValue,
				min: -1,
				unit: "d");

			setting.Value = value;

			return SettingsRowHeight;
		}

		private string GlobalModifierBuffer;
		public override float CreateSettingGlobal(float offsetY, float viewWidth)
		{
			(var use, var value) = CreateNumericGlobal(
				offsetY,
				viewWidth,
				"SY_CA.GestationPeriodDaysGlobal".Translate(),
				"SY_CA.TooltipGestationPeriodDaysGlobal".Translate(),
				SettingGestationPeriodDays.UseGlobalModifier,
				SettingGestationPeriodDays.GlobalModifier,
				SettingGestationPeriodDays.GlobalModifierDefault,
				ref GlobalModifierBuffer,
				min: SettingGestationPeriodDays.MinimumModifier,
				max: SettingGestationPeriodDays.MaximumModifier);
			SettingGestationPeriodDays.UseGlobalModifier = use;
			SettingGestationPeriodDays.GlobalModifier = value;

			return SettingsThinRowHeight;
		}
	}
}
