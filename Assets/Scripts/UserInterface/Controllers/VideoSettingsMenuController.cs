// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assignment1.UserInterface.Controllers;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface {
	public class VideoSettingsMenuController : SettingsMenuController<Resolution> {
		
		protected override string ScrollViewID => "resolution";
		protected override Resolution[] ScrollViewButtonTypeArray => Screen.resolutions;


		protected override void Apply() {
			Screen.SetResolution(NewValue.width, NewValue.height, true);
			
		}
	}
}