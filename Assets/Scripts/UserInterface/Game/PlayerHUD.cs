// © 2020 Joshua Petersen. All rights reserved.
/// <file>
/// <copyright> © 2020 Joshua Petersen. All rights reserved. </copyright>
/// </file>

using System;
using Assignment1;
using Assignment1.Gameplay;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

namespace UserInterface.Game {
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// I violated the naming convention due to HUD being an acronym.
	/// </remarks>
	[RequireComponent(typeof(PanelRenderer))]
	public class PlayerHUD : Singleton<PlayerHUD> {

		private Label amountCollected;

		private PanelRenderer panelRenderer;

		private Label timerLabel;

		private void Start() {
			panelRenderer = GetComponent<PanelRenderer>();
			amountCollected = panelRenderer.visualTree.Query<Label>(name: "AmountCollected");
			timerLabel = panelRenderer.visualTree.Query<Label>(name: "Timer");
		}


		// Update is called once per frame
		void Update() {
			timerLabel.text = GameplayManager.Instance.Timer.ToString();
		}
	}
}