﻿using CustomizeAnimals.Controls;
using CustomizeAnimals.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace CustomizeAnimals.Controls
{
	internal class GeneralSettingsControls : BaseControl
	{
		#region PROPERTIES
		private GeneralSettings Settings => GlobalSettings.GeneralSettings;
		#endregion

		#region FIELDS
		#endregion

		#region PUBLIC METHODS
		public float DrawTrainabilityLimitsControls(float offsetY, float viewWidth)
		{
			var controlWidth = GetControlWidth(viewWidth);
			var halfWidth = viewWidth / 2;
			var quarterWidth = halfWidth / 2 - 2;
			var checkboxSize = SettingsRowHeight - 8;
			var checkboxOffset = (SettingsRowHeight - checkboxSize) / 2;

			float startOffsetY = offsetY;
			float offsetX = 0;


			// Trainable Limits Label
			if (Settings.DisableHaulSizeLimit || Settings.DisableRescueSizeLimit)
				GUI.color = ModifiedColor;
			Widgets.Label(new Rect(offsetX, offsetY, controlWidth, SettingsRowHeight), "SY_CA.TrainableLimits".Translate());
			GUI.color = OriColor;

			offsetX += controlWidth;

			// Rescue: BodySize Limit
			var selected = Settings.DisableHaulSizeLimit;
			Widgets.Checkbox(offsetX, offsetY + checkboxOffset, ref selected, checkboxSize);
			DrawTooltip(new Rect(offsetX, offsetY, quarterWidth - 12, SettingsRowHeight), "SY_CA.TooltipRescueLimit".Translate());
			offsetX += checkboxSize + 2;
			var rect = new Rect(offsetX, offsetY, quarterWidth - checkboxSize - 12, SettingsRowHeight);
			Widgets.Label(rect, "SY_CA.RescueLimit".Translate());
			Settings.DisableHaulSizeLimit = selected ^ Widgets.ButtonInvisible(rect);

			offsetX = controlWidth + quarterWidth + 2;

			// Haul: BodySize Limit
			selected = Settings.DisableRescueSizeLimit;
			Widgets.Checkbox(offsetX, offsetY + checkboxOffset, ref selected, checkboxSize);
			DrawTooltip(new Rect(offsetX, offsetY, quarterWidth - 12, SettingsRowHeight), "SY_CA.TooltipHaulLimit".Translate());
			offsetX += checkboxSize + 2;
			rect = new Rect(offsetX, offsetY, quarterWidth - checkboxSize - 12, SettingsRowHeight);
			Widgets.Label(rect, "SY_CA.HaulLimit".Translate());
			Settings.DisableRescueSizeLimit = selected ^ Widgets.ButtonInvisible(rect);


			// Next row
			offsetX = 0;
			offsetY += SettingsRowHeight;

			return offsetY - startOffsetY;
		}
		#endregion
	}
}