// © 2020 Joshua Petersen. All rights reserved.
 using UnityEngine;
using UnityEngine.UIElements;

namespace Assignment1.UserInterface.Components {
	public class VerticalBoxElement : VisualElement {


		public VerticalBoxElement() {
			StyleSheet styleSheet = Resources.Load<StyleSheet>(
				@"UserInterface/Styles/CustomElements/VerticalBox");
			styleSheets.Add(
				styleSheet);	
			

			AddToClassList("VBox");
		}

		public new class UxmlFactory : UxmlFactory<VerticalBoxElement, UxmlTraits> {}

		public new class UxmlTraits : VisualElement.UxmlTraits {}
	}
}