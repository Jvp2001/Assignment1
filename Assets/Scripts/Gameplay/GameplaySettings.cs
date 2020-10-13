using UnityEngine;

namespace Assignment1.Gameplay {
	public class GameplaySettings {

		public static readonly Difficulty[] Difficulties = { Difficulty.Easy, Difficulty.Normal, Difficulty.Hard };
		public Difficulty Difficulty { get; set; } = Difficulty.Normal;
			
		public GameplaySettings() {
		}
	}
}