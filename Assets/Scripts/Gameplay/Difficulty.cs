// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.ComponentModel;
using UnityEngine;

namespace Assignment1.Gameplay {
	/// <summary>
	/// Enum for controlling the difficulty of the game. 
	/// </summary>
	/// <remarks>
	/// I marked each value with the <see cref="DescriptionAttribute"/> so I can easily convert each value to a string, useful for my <see cref="Assignment1.UserInterface.Controllers.GameplaySettingsMenuController"/> class.
	/// </remarks>
	[Serializable]
	public enum Difficulty {
		[Description("Easy")]
		Easy = 0,
		[Description("Normal")]
		Normal = 1,
		[Description("Hard")]
		Hard = 2
		
		
	}
}