using System;
using System.Collections.Generic;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

namespace Assignment1.UserInterface {
	/// <summary>
	/// <para>
	/// Base class for all of my menu controllers
	/// </para>
	/// </summary>
	[RequireComponent(typeof(PanelRenderer))]
	
	public abstract class MenuController : MonoBehaviour {

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
		protected PanelRenderer PanelRenderer => GetComponent<PanelRenderer>();

		/// <summary>
		///<para>
		/// A Dictionary which maps the name of each button to its OnClicked action.
		/// </para>
		/// <remarks>
		/// </summary>
		protected abstract Dictionary<string, Action<Button>> ButtonActions { get; }

		
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

		private void OnEnable() {
			SceneManager.sceneLoaded += OnSceneLoaded;
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
		///<seealso cerf="OnSceneLoaded"/>
		///<seealso cref="OnEnable"/>
		///<seealso cref="OnDisable"/>
		protected virtual void Initialise() {
		}

		private void SetupButtonActions() {
			ForEach<Button>(button => { button.clicked += () => ButtonActions[button.name.ToLower()](button); });
		}

		private void OnDisable() {
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}
	}
}