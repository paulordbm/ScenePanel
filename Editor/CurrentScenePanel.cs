﻿/// ------------------------------------------------
/// <summary>
/// Current Scene Panel
/// Purpose: 	Display all the details for the current scene.
/// Author:		Juan Silva
/// Date: 		November 29, 2015
/// Copyright (c) Tuxedo Berries All rights reserved.
/// </summary>
/// ------------------------------------------------
using UnityEditor;
using UnityEngine;
using TuxedoBerries.ScenePanel.Drawers;

namespace TuxedoBerries.ScenePanel
{
	public class CurrentScenePanel : BaseUpdateablePanel
	{
		private const string PANEL_TITLE = "Current Scene";
		private const string PANEL_TOOLTIP = "Display all the detials of the current scene";
		private ScrollableContainer _scrolls;
		private SceneEntityDrawer _drawer;
		private ScreenshotDrawer _screenshotDrawer;
		private SceneDatabaseProvider _provider;

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
				_drawer = new SceneEntityDrawer ();
			if (_screenshotDrawer == null)
				_screenshotDrawer = new ScreenshotDrawer ();
			if (_provider == null)
				_provider = new SceneDatabaseProvider ();
			if (_scrolls == null)
				_scrolls = new ScrollableContainer ("CurrentScenePanel", true);
		}
		/// <summary>
		/// Draws the content.
		/// </summary>
		protected override void DrawContent ()
		{
			UpdateCurrentScene ();

			EditorGUILayout.Space ();
			EditorGUILayout.BeginHorizontal ();
			{
				GUILayout.Space (20);
				_scrolls.DrawScrollable ("main", Content);
			}
			EditorGUILayout.EndHorizontal ();

		}

		private void Content()
		{
			_drawer.DrawDetailEntity (_provider.CurrentActive);
			_screenshotDrawer.DrawSnapshot (_provider.CurrentActive);
		}

		private void UpdateCurrentScene()
		{
			_provider.SetAsActive (EditorApplication.currentScene);
		}

		/// <summary>
		/// Execute the Before Update event
		/// </summary>
		protected override void BeforeUpdate()
		{
			if (_provider == null)
				return;

			_provider.Refresh ();
		}
	}
}
