// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface.Controllers {
	/// <summary>
	/// A Base class for the <see cref="GameplaySettingsMenuController"/> and the <see cref="VideoSettingsMenuController"/>
	/// </summary>
	public abstract class SettingsMenuController : MenuController {

		//protected sealed override bool WillSetupButtons => true;

		protected sealed override Dictionary<string, Action<Button>> ButtonActions => new Dictionary<string, Action<Button>> {
			{"apply", button => Apply()},
			{"back", button => Back()}
		};

		/// <summary>
		///<para>
		/// <inheritdoc cref="MenuController.Initialise"/>
		/// This class overrides the its parent method due to <see cref="WillSetupButtons"/> being false.
		/// </param>
		/// <seealso cref="MenuController.ForEach{T}"/>
		/// <seealso cref="MenuController.Initialise"/>
		/// </summary>
		protected override void Initialise() {
			Logger.Log("Settings Menu: Initialised!");
			
//			ForEach<Button>(button => {
//				string buttonName = button.name.ToLower();
//				switch (buttonName) {
//					case "apply":
//						Logger.Log("SettingsMenu: Found apply button.");
//						button.clicked += () => ButtonActions["apply"](button);
//						break;
//					case "back":
//						Logger.Log("SettingsMenu: Found back button.");
//						button.clicked += () => {
//							ButtonActions["back"](button);
//							
//						};
//						break;
//				}	
//			});
		}

		/// <summary>
		/// This method allows the child class implement behaviour for the Apply, button when it is clicked.
		/// </summary>
		/// <seealso cref="Button"/>
		protected abstract void Apply();

		/// <summary>
		/// This method allows the child class implement behaviour for the Back, button when it is clicked.
		/// </summary>
		/// <seealso cref="Button"/>	
		protected virtual void Back() {
			SceneManager.LoadScene("OptionsMenu");
			Logger.Log("Back button clicked!");
		}

	}
}