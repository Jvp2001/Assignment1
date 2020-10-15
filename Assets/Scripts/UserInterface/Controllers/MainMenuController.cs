using System;
using System.Collections.Generic;
using Unity.UIElements.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface.Controllers {
	public sealed class MainMenuController : MenuController {
		
		//TODO: change the "Play" button logic to load the correct scene later.
		protected override Dictionary<string, Action<Button>> ButtonActions =>
			new Dictionary<string, Action<Button>> {
				{
					"play", button => SceneManager.LoadScene("Scenes/MainLevel")
				}, {
					"options", Options
				},
				{"exit", button => Application.Quit(0)}
			};

		
		private static void Options(Button button) {
			Logger.Log("MainMenu: Options clicked!");
			SceneManager.LoadScene("Scenes/Menus/OptionsMenu");
		}

	}
}