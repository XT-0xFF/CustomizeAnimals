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
	internal class ControlFilthRate : BaseSettingControl
	{
		public override float CreateSetting(float offsetY, float viewWidth, AnimalSettings animalSettings)
		{
			if (animalSettings.IsHumanLike)
				return 0f;

			var setting = (NullableFloatSetting)animalSettings.GeneralSettings["FilthRate"];
			var value = CreateNullableNumeric(
				offsetY,
				viewWidth,
				"SY_CA.FilthRate".Translate(),
				"SY_CA.FilthRateDisabled".Translate(),
				"SY_CA.TooltipFilthRate".Translate(),
				"SY_CA.TooltipFilthRateChk".Translate(),
				setting.IsModified(),
				setting.Value,
				setting.DefaultValue,
				min: StatDefOf.FilthRate.minValue,
				max: StatDefOf.FilthRate.maxValue);

			setting.Value = value;

			return SettingsRowHeight;
		}

		public override float CreateSettingGlobal(float offsetY, float viewWidth)
		{
			(var use, var value) = CreateNullableNumericGlobal(
				offsetY,
				viewWidth,
				"SY_CA.MaximumFilthRate".Translate(),
				"SY_CA.FilthRateDisabled".Translate(),
				"SY_CA.TooltipMaximumFilthRate".Translate(),
				"SY_CA.TooltipMaximumFilthRateChk".Translate(),
				SettingFilthRate.UseMaximumFilthRate,
				SettingFilthRate.MaximumFilthRate,
				SettingFilthRate.DefaultMaximum,
				min: StatDefOf.FilthRate.minValue,
				max: StatDefOf.FilthRate.maxValue);

			SettingFilthRate.UseMaximumFilthRate = use;
			SettingFilthRate.MaximumFilthRate = value;

			return SettingsRowHeight;
		}
	}
}
