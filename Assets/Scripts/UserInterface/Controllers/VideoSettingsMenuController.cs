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
	public class VideoSettingsMenuController : SettingsMenuController {
		private Slider brightnessSlider;

		private Resolution newResolution;

		private Button oldResolutionButton;


		protected override void Initialise() {
			ForEach<ScrollView>(listView => {
				if (listView.name.ToLower() == "resolution") {
					foreach (Resolution screenResolution in Screen.resolutions) {
						Button button = new Button {text = screenResolution.ToString()};
						button.AddToClassList("ResolutionButton");

						button.clicked += () => {
							button.AddToClassList("Selected");
							if (!(oldResolutionButton is null) && button != oldResolutionButton) {
								oldResolutionButton?.RemoveFromClassList("Selected");
							}
							oldResolutionButton = button;

							newResolution = screenResolution;
							Logger.Log(newResolution.ToString());
						};
						listView.Add(button);
					}  
				}
			});

			ForEach<Slider>(slider => {
				string sliderName = slider.name.ToLower();
				if (sliderName == "brightness") {
					brightnessSlider = slider;
					brightnessSlider.tooltip = brightnessSlider.value.ToString(CultureInfo.CurrentCulture);
				}
			});
		}

		protected override void Apply() {
			Screen.SetResolution(newResolution.width, newResolution.height, true);
			if (!(brightnessSlider is null)) {
				float newValue = brightnessSlider.value;
				RenderSettings.ambientLight = new Color(newValue, newValue, newValue, 1.0f);
				RenderSettings.ambientIntensity = newValue;
			}
		}
	}
}