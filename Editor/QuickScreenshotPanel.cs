﻿/// ------------------------------------------------
/// <summary>
/// Quick Screenshot Panel
/// Purpose: 	Quickly take screenshots of the game.
/// Author:		Juan Silva
/// Date: 		November 29, 2015
/// Copyright (c) Tuxedo Berries All rights reserved.
/// </summary>
/// ------------------------------------------------
using TuxedoBerries.ScenePanel.Drawers;

namespace TuxedoBerries.ScenePanel
{
	public class QuickScreenshotPanel : BaseUpdateablePanel
	{
		private const string PANEL_TITLE = "Snapshots";
		private const string PANEL_TOOLTIP = "Stake quick snapshots of the game";
		private ScreenshotDrawer _drawer;

		/// <summary>
		/// Applies the title.
		/// </summary>
		protected override void ApplyTitle()
		{
			this.titleContent.text = PANEL_TITLE;
			this.titleContent.tooltip = PANEL_TOOLTIP;
		}

		/// <summary>
		/// Checks the components.
		/// </summary>
		protected override void CheckComponents()
		{
			if (_drawer == null)
				_drawer = new ScreenshotDrawer ();
		}

		/// <summary>
		/// Draws the content.
		/// </summary>
		protected override void DrawContent ()
		{
			_drawer.DrawFull ();
		}
	}
}

