// © 2020 Joshua Petersen. All rights reserved.

using System;
using System.Collections;
using Assignment1.Gameplay;
using UnityEngine;

namespace Assignment1.Gameplay {

	public delegate void CountdownFinished();


	public class CountdownTimer : MonoBehaviour {
		private bool paused = true;
		private bool TimerIsFinished => !Paused && CurrentTime <= 0.0f;


		public CountdownTimer(TimerOptions startTime) {
			CurrentTime = startTime;
		}

		public float CurrentTime { get; set; }

		/// <summary>
		/// Toggles the timer.
		/// </summary>
		public bool Paused {
			get => paused;
			set {
				paused = value;
				if (paused) {
					StopCoroutine(nameof(UpdateTimer));
				} else {
					StartCoroutine(nameof(UpdateTimer));
				}
			}
		}


		public event CountdownFinished OnCountdownFinished;

		/// <summary>
		/// Updates the timer every second.
		/// </summary>
		/// <returns> <see cref="IEnumerator"/> because it is a coroutine.</returns>
		private IEnumerator UpdateTimer() {
			yield return new WaitForSeconds(1.0f);
			Logger.Log($"ELAPSED TIME: {CurrentTime}");
			--CurrentTime;

			if (TimerIsFinished) {
				OnCountdownFinished?.Invoke();
			} else {
				
				StartCoroutine(nameof(UpdateTimer))
			}
		}


		/// <summary>
		/// Converts the <see cref="CurrentTime"/> into a human readable, digital clock, formatted string. This is used in the <see cref="Assignment1.UserInterface.Game.PlayerHUD"/> class.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			float seconds = CurrentTime % 60;
			return $@"{Mathf.Floor(CurrentTime / 60.0f)}:{(seconds < 10 ? "0" : "")}{seconds}";
		}
	}
}