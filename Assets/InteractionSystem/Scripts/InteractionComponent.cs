// © 2020 Joshua Petersen. All rights reserved.

using InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = Assignment1.Logger;

namespace InteractionSystem {
	
	/// <summary>
	/// Allows the player to interact with interactable (<see cref="InteractionSystem.InteractableComponent"/>) enabled <see cref="GameObject"/>s. 
	/// </summary>
	public class InteractionComponent : MonoBehaviour {
		[SerializeField]
		private float interactLength = 10.0f;

		private bool canInteract = false;

		private RaycastHit hitResult;

		private InteractableComponent interactableComponent;
		private Camera mainCamera;
		private Vector2 mousePosition = Vector2.zero;

		private Transform CameraTransform => mainCamera.transform;

		private string InteractKeyName => GetComponent<PlayerInput>()?.currentActionMap["Interact"].controls[0].name.ToUpper();

		// Start is called before the first frame update
		void Start() {
			mainCamera = Camera.main;

			if (!mainCamera) {
				return;
			}

			
		}

		// Update is called once per frame
		void Update() {
			if (CheckForAnInteractableObject()) {
				GameObject hitObject = hitResult.transform.gameObject;
				Logger.Log($"Hit Object: {hitObject.name}");
				interactableComponent = hitObject.GetComponent<InteractableComponent>();
				canInteract = !(interactableComponent is null) && interactableComponent.isActiveAndEnabled &&
				              hitObject.gameObject.layer == LayerMask.NameToLayer("Interactable");
				if (canInteract) {
					Logger.Log($"Found: {interactableComponent.gameObject.name}");
				}
			}
		}

		private void OnGUI() {
			if (canInteract) {
				string text = $"Press {InteractKeyName}";
				GUIStyle style = new GUIStyle {fontSize = 50};
				style.normal.textColor = Color.white;
				Vector2 textSize = GUI.skin.label.CalcSize(new GUIContent(text));

				GUI.Label(
					new Rect(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(textSize.x, textSize.y)),
					text, style);
			}
		}

		public void OnLook(InputAction.CallbackContext context) {
			mousePosition += context.ReadValue<Vector2>();
		}

		private bool CheckForAnInteractableObject() {
			Ray ray = new Ray(CameraTransform.position, CameraTransform.forward);

#if UNITY_EDITOR
			Debug.DrawLine(CameraTransform.position, CameraTransform.forward * interactLength, Color.red);
#endif


			return Physics.Raycast(ray, out hitResult, interactLength);
		}

		public void OnInteraction(InputAction.CallbackContext context) {
			if (!canInteract) return;
			canInteract = false;
			hitResult.collider.gameObject.layer = LayerMask.NameToLayer("Default");
			interactableComponent?.OnInteractionCompleted(gameObject);
		}
	}
}