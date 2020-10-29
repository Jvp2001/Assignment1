// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assignment1.Gameplay;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface.Controllers {
	public class GameplaySettingsMenuController : SettingsMenuController {
		private Difficulty newDifficulty;

		private Button oldDifficultyButton;

		protected override void Initialise() {
			ForEach<ScrollView>(listView => {
				if (listView.name.ToLower() == "resolution") {
					foreach (Difficulty difficulty in GameplaySettings.Difficulties) {
						Button button = new Button {text = difficulty.ToString()};
						button.AddToClassList("ResolutionButton");
						button.clicked += () => {
							button.AddToClassList("Selected");
							if (!(oldDifficultyButton is null) && button != oldDifficultyButton) {
								oldDifficultyButton?.RemoveFromClassList("Selected");
							}

							newDifficulty = difficulty;
							oldDifficultyButton = button;
						};
						listView.Add(button);
					}
				}
			});
		}

		protected override void Apply() {
			GameplayManager.Instance.GameplaySettings.Difficulty = newDifficulty;
		}
	}
}