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
	/// <typeparam name="T">The type that each <see cref="ScrollView"/><see cref="Button"> represents</typeparam>
	// TODO: Fix video and gameplay options menu
	public abstract class SettingsMenuController<T> : MenuController {


		private Button oldScrollViewButton;

		protected T NewValue { get; private set; }

		protected sealed override Dictionary<string, Action<Button>> ButtonActions =>
			new Dictionary<string, Action<Button>> {
				{"apply", button => Apply()},
				{"back", button => Back()}
			};

		/// <summary>
		///<para>
		/// <inheritdoc cref="MenuController.Initialise"/>
		/// This class overrides the its parent method due to <see cref="WillSetupButtons"/> being false.
		/// </param>
		/// </summary>
		/// <remarks>
		/// I am using <see cref="string.Equals(string, string, StringComparison)"/> because I want it to throw a <see cref="NullReferenceException"/> if one of the two strings that I am comparing is null; Also, Rider recommended I should use it instead of the <see cref="string.op_Equality"/> operator. 
		/// </remarks>
		/// <seealso cref="MenuController.ForEach{T}"/>
		/// <seealso cref="MenuController.Initialise"/>
		protected override void Initialise() {
			Logger.Log("Settings Menu: Initialised!");
			ForEach<ScrollView>(listView => {
				if (string.Equals(listView.name, ScrollViewID, StringComparison.CurrentCultureIgnoreCase)) {
					foreach (T type in ScrollViewButtonTypeArray) {
						Button button = new Button {text = type.ToString()};

						button.clicked += () => {
							button.AddToClassList("Selected");
							if (!(oldScrollViewButton is null) && button != oldScrollViewButton) {
								oldScrollViewButton.RemoveFromClassList("Selected");
							}
							oldScrollViewButton = button;

							NewValue = type;
							
						};
						listView.Add(button);
					}  
				}
			});
		}

		protected abstract string ScrollViewID { get; }

		protected abstract T[] ScrollViewButtonTypeArray { get; }

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