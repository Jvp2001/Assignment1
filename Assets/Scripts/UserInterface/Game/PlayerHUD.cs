// © 2020 Joshua Petersen. All rights reserved.

using System;
using Assignment1;
using Assignment1.Gameplay;
using Assignment1.Pickups;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface.Game {
	/// <summary>
	/// Displays the countdown timer and the number of gems you have and need to collect to win the game. 
	/// </summary>
	/// <remarks>
	/// I violated the naming convention due to HUD being an acronym.
	/// </remarks>
	[RequireComponent(typeof(PanelRenderer))]
	public class PlayerHUD : Singleton<PlayerHUD> {

		private Label amountCollected;

		private PanelRenderer panelRenderer;

		private Label timerLabel;

		private int TotalNumberOfGemsInScene =>  FindObjectsOfType<Gem>().Length;

		private void Start() {
			panelRenderer = GetComponent<PanelRenderer>();
			amountCollected = panelRenderer.visualTree.Query<Label>(name: "AmountCollected");
			timerLabel = panelRenderer.visualTree.Query<Label>(name: "Timer");
			GameplayManager.Instance.PlayerData.AmountCollectedChanged += OnAmountCollectedChanged;
		}

		private void OnAmountCollectedChanged(short value) {
			amountCollected.text = $"{value}/{TotalNumberOfGemsInScene}";

		}


		// Update is called once per frame
		void Update() {
			timerLabel.text = GameplayManager.Instance.Timer.ToString();
		}
	}
}