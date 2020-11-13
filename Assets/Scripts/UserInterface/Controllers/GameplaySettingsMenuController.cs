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
	public class GameplaySettingsMenuController : SettingsMenuController<Difficulty> {

		protected override string ScrollViewID => "difficulties";
		protected override Difficulty[] ScrollViewButtonTypeArray => GameplaySettings.Difficulties;
		protected override void Apply() {
			Logger.Log("Applying Game Settings!");
			GameplayManager.Instance.GameplaySettings.Difficulty = NewValue;
			Logger.Log($"Gameplay Settings: new difficulty: {GameplayManager.Instance.GameplaySettings.Difficulty}");
		}
	}
}