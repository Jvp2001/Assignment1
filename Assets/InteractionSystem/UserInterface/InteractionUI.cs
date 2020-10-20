// © 2020 Joshua Petersen. All rights reserved.
 using Assignment1;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Game.Interaction {
	public class InteractionUI : Singleton<InteractionUI> {
		//TODO: Get from Interact Key name from the InputSystem
		private string text = "E";
   
		[SerializeField]
		private Text interactKeyTextComponent;
		[SerializeField]
		private Text interactMessageTextComponent;
		public Text InteractMessageTextComponent => interactMessageTextComponent;

		public string InteractMessage {
			get => InteractMessageTextComponent.text;
			set => InteractMessageTextComponent.text = value;
		}
    

		// Start is called before the first frame update
		void 
			Start() {
			interactKeyTextComponent.text = text;
			gameObject.SetActive(false);
			transform.Rotate(0,180,0);
		}

		// Update is called once per frame
		void Update()
		{
        
		}
	}
}
