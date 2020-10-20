// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface {
	public class OptionsMenuController : MenuController {

		protected override Dictionary<string, Action<Button>> ButtonActions => 
		new Dictionary<string, Action<Button>> {
				{ "gameplay", button =>  SceneManager.LoadScene("GameplayOptionsMenu") }, 
				{ "back", button => SceneManager.LoadScene("MainMenuScene") },

				{  "video", Video }
			};


		private void Video(Button button) {
			SceneManager.LoadScene("VideoOptionsMenu");
		}




	}

}