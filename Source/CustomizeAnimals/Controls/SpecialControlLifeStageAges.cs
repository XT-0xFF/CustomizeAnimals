﻿using CustomizeAnimals.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace CustomizeAnimals.Controls
{
	internal class SpecialControlLifeStageAges : BaseSpecialSettingControl
	{
		#region PROPERTIES
		private List<ControlLifeStageAge> LifeStageAgeControls { get; } = new List<ControlLifeStageAge>();
		#endregion

		#region METHODS
		public override float CreateSetting(float offsetY, float viewWidth, AnimalSettings animalSettings)
		{
			var setting = (SpecialSettingLifeStageAges)animalSettings.ReproductionSettings["LifeStageAges"];

			var totalHeight = offsetY;

			// Separator
			Widgets.ListSeparator(ref totalHeight, viewWidth - 16, "SY_CA.LifeStageAges".Translate());
			totalHeight += 2;
			Text.Anchor = TextAnchor.MiddleLeft;

			if (LifeStageAgeControls.Count == 0)
				foreach (var lifeStageAge in setting.LifeStageAges)
					LifeStageAgeControls.Add(new ControlLifeStageAge(lifeStageAge));

			foreach (var control in LifeStageAgeControls)
				totalHeight += control.CreateSetting(totalHeight, viewWidth);
			return totalHeight - offsetY;
		}

		public override void Reset()
		{
			LifeStageAgeControls.Clear();
		}
		#endregion

		#region CLASSES
		private class ControlLifeStageAge : BaseControl
		{
			#region PROPERTIES
			public LifeStageAgeSetting Setting { get; }
			#endregion

			#region FIELDS
			protected string MinAgeBuffer = null;
			#endregion

			#region CONSTRUCTORS
			public ControlLifeStageAge(LifeStageAgeSetting lifeStageAge)
			{
				Setting = lifeStageAge;
			}
			#endregion

			#region METHODS
			public float CreateSetting(float offsetY, float viewWidth)
			{
				if (Setting == null)
					return 0f;

				var oriOffsetY = offsetY;

				// Min Age
				var name = Setting.LifeStageAge?.def?.label?.CapitalizeFirst() ?? "???";
				Setting.MinAge = CreateNumeric(
					offsetY,
					viewWidth,
					name,
					"SY_CA.TooltipLifeStageAgeMinAge".Translate(),
					Setting.IsModified(),
					Setting.MinAge,
					Setting.DefaultMinAge,
					ref MinAgeBuffer,
					convert: ConvertYearToDays,
					unit: "d");
				offsetY += SettingsRowHeight;

				return offsetY - oriOffsetY;
			}
			#endregion
		}
		#endregion
	}
}
