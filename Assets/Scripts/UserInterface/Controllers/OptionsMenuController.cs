// © 2020 Joshua Petersen. All rights reserved.

using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface.Controllers {
	public class OptionsMenuController : MenuController {

		protected override Dictionary<string, Action<Button>> ButtonActions =>
			new Dictionary<string, Action<Button>> {
				{"gameplay", button => SceneManager.LoadScene("Scenes/Menus/GameplayOptionsMenu")},
				{"back", button => SceneManager.LoadScene("Scenes/Menus/MainMenu")},

				{"video", button => SceneManager.LoadScene("VideoOptionsMenu")},
			};

	}

}