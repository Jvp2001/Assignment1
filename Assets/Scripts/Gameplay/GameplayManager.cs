// © 2020 Joshua Petersen. All rights reserved.

using System;
using System.Collections;
using System.Reflection.Emit;
using Gameplay;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assignment1.UserInterface.Game;

namespace Assignment1.Gameplay {

	/// <summary>
	/// A <see cref="Singleton{T}"/> class which contains references for other gameplay related data.
	/// Also, it controls the win and lose state of the game. 
	/// </summary>
	/// <seealso cref="CountdownTimer"/>
	/// <seealso cref="PlayerData"/>
	/// <seealso cref="GameplaySettings"/>
	[RequireComponent(typeof(CountdownTimer))]
	public class GameplayManager : Singleton<GameplayManager> {

		[SerializeField]
		private GameplaySettings gameplaySettings = new GameplaySettings();

		/// <summary>
		/// Controls if the end of game message should be displayed.
		/// </summary>
		private bool displayEndOfGameMessage = false;

		/// <summary>
		/// Store the message which will be displayed at the end of the game. 
		/// </summary>
		private string endOfGameMessage = "";

		[SerializeField]
		private short numberOfGemsToWin = 5;


		public GameplaySettings GameplaySettings => gameplaySettings;

		public PlayerData PlayerData { get; } = new PlayerData();

		public CountdownTimer Timer { get; private set; }

		public short NumberOfGemsToWin => numberOfGemsToWin;


		private void Awake() {
			Application.targetFrameRate = 60;
			Timer = GetComponent<CountdownTimer>();
			Timer.CurrentTime = GameplaySettings.CountdownTime;
			
		}

		private void Start() {
			Timer.OnCountdownFinished += OnCountdownFinished;
			PlayerData.AmountCollectedChanged += CheckForGameCompletion;
		}

		private void OnGUI() {
			if (displayEndOfGameMessage) {
				GUIStyle style = new GUIStyle {fontSize = 50};
				GUI.Label(new Rect(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(600, 100)),
					endOfGameMessage, style);
			}
		}

		/// <summary>
		/// A callback method for my <see cref="AmountCollectedChanged"/> delegate. If the player has collected the minimum number of gems, then it will call the <see cref="GameCompleted"> Coroutine. 
		/// <param name="value"></param>
		/// 
		private void CheckForGameCompletion(short value) {
			if (PlayerData.AmountCollected >= NumberOfGemsToWin) {
				StartCoroutine(nameof(GameCompleted));
			}
		}

		private IEnumerator GameCompleted() {
			yield return new WaitUntil(() => PlayerData.AmountCollected >= NumberOfGemsToWin);
			StartCoroutine(nameof(GameFinished), "Game Completed!");
		}

		/// <summary>
		/// This coroutine display a message, at the end of the game, using IMGUI system.
		/// </summary>
		/// <param name="message"> The text that you want to write on the screen .</param>
		/// <returns></returns>
		private IEnumerator GameFinished(string message) {
			FindObjectOfType<PlayerInput>().enabled = false;
			FindObjectOfType<PlayerHUD>().enabled = false;
			endOfGameMessage = message;
			displayEndOfGameMessage = true;
			yield return new WaitForSeconds(3);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			displayEndOfGameMessage = false;
			SceneManager.LoadScene("MainMenu");
		}

		private void OnCountdownFinished() {
			StartCoroutine(nameof(GameOver));
		}

		private IEnumerator GameOver() {
			yield return new WaitUntil(() => Timer.CurrentTime < 1f);
			StartCoroutine(nameof(GameFinished), "Game Over!");
		}
	}
}