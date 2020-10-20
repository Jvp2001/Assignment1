// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.ComponentModel;
using UnityEngine;

namespace Assignment1.Gameplay {
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