// © 2020 Joshua Petersen. All rights reserved.

using System;
using System.Collections.Generic;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Random = System.Random;

namespace Assignment1.UserInterface {
	/// <summary>
	/// <para>
	/// Base class for all of my menu controllers
	/// </para>
	/// </summary>
	[RequireComponent(typeof(PanelRenderer))]
	public abstract class MenuController : MonoBehaviour {
		private PanelRenderer panelRenderer;

		/// <summary>
		/// This property can be overriden by a child class to tell the <see cref="MenuController"/> parent class that it wants to handle when
		/// buttons get setup.
		/// <remarks>
		/// Normally not overriden in base child classes
		/// </remarks>
		/// </summary>
		protected virtual bool WillSetupButtons { get; } = true;

		/// <summary>
		/// This property will get <see cref="Unity.UIElements.Runtime.PanelRenderer"/> component from its game object 
		/// </summary>
		/// 
		protected PanelRenderer PanelRenderer => panelRenderer;

		/// <summary>
		///<para>
		/// A Dictionary which maps the name of each button to its OnClicked action.
		/// </para>
		/// <remarks>
		/// </summary>
		protected abstract Dictionary<string, Action<Button>> ButtonActions { get; }

		private void Awake() {
			SceneManager.sceneLoaded += OnSceneLoaded;
			panelRenderer = GetComponent<PanelRenderer>();
		}


		/// <summary>
		/// <para>
		/// A simple wrapper around the ForEach method in the <see cref="UQueryBuilder{T}"/>.
		/// </para>
		/// </summary>
		/// <seealso cref="PanelRenderer"/>
		/// <param name="action">A callback which is be executed on every iteration of the for each loop.</param>
		/// <typeparam name="T">The type of the UI element</typeparam>
		protected void ForEach<T>(Action<T> action) where T : VisualElement {
			PanelRenderer.visualTree.Query<T>().ForEach(action);
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
			Cursor.visible = true;
			PanelRenderer.visualTree.Focus();
			if (WillSetupButtons)
				SetupButtonActions();
			Initialise();
		}

		///<summary>
		///<para>
		/// Allows the child class to execute its own logic when it is initialised.   
		///</para>
		///<remarks>
		///<para>
		/// This method is called when the scene is loaded.
		///</para>
		///</remarks>
		///</summary>
		///<seealso cref="Awake"/>
		///<seealso cerf="OnSceneLoaded"/>
		protected virtual void Initialise() {
		}

		private void SetupButtonActions() {
			ForEach<Button>(button => {
				button.clicked += () => {
					string key = button.name.ToLower();
					if (!ButtonActions.ContainsKey(key))
					{
						Logger.LogError($"Cannot find key: ${key} in ButtonActions.");
						return;

					}
					ButtonActions[key](button);
				};
			});
		}
	}
}