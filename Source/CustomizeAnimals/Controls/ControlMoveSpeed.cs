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
	internal class ControlMoveSpeed : BaseSettingControl
	{
		public override float CreateSetting(float offsetY, float viewWidth, AnimalSettings animalSettings)
		{
			var setting = (NullableFloatSetting)animalSettings.GeneralSettings["MoveSpeed"];
			var value = CreateNumeric(
				offsetY,
				viewWidth,
				"SY_CA.MoveSpeed".Translate(),
				"SY_CA.TooltipMoveSpeed".Translate(),
				setting.IsModified(),
				setting.Value ?? StatDefOf.MoveSpeed.defaultBaseValue, // Value should never be null at this point
				setting.DefaultValue ?? StatDefOf.MoveSpeed.defaultBaseValue, // DefaultValue should never be null at this point
				min: StatDefOf.MoveSpeed.minValue,
				max: StatDefOf.MoveSpeed.maxValue,
				unit: "c/s");

			setting.Value = value;

			return SettingsRowHeight;
		}

		public override float CreateSettingGlobal(float offsetY, float viewWidth)
		{
			(var use, var value) = CreateNumericGlobal(
				offsetY,
				viewWidth,
				"SY_CA.MoveSpeed".Translate(),
				"SY_CA.TooltipMoveSpeed".Translate(),
				SettingMoveSpeed.UseGlobalModifier,
				SettingMoveSpeed.GlobalModifier,
				SettingMoveSpeed.GlobalModifierDefault,
				SettingMoveSpeed.MinimumModifier,
				SettingMoveSpeed.MaximumModifier);

			SettingMoveSpeed.UseGlobalModifier = use;
			SettingMoveSpeed.GlobalModifier = value;

			return SettingsRowHeight;
		}
	}
}
