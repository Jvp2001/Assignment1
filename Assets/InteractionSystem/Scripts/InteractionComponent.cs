using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UserInterface.Game.Interaction;
using Logger = Assignment1.Logger;

namespace InteractionSystem {

	public class InteractionComponent : MonoBehaviour {


		private const float InteractLength = 50.0f;

		private RaycastHit hitResult;

		private InteractableComponent interactableComponent;
		private Camera mainCamera;
		private InteractionUI interactionUI;

		// Start is called before the first frame update
		void Start() {
			mainCamera = Camera.main;

			if (!mainCamera) {
				return;
			}

			Logger.Log($"Found camera: {mainCamera.name}");
			interactionUI = FindObjectOfType<InteractionUI>();
			if (!interactionUI) {
				return;
			}
		}

		// Update is called once per frame
		void Update() {
			if (CheckForInteractableObject()) {
				GameObject hitObject = hitResult.transform.gameObject;
				//Logger.Log($"Hit Object: {hitObject.name}");
				interactableComponent = hitObject.GetComponent<InteractableComponent>();
				if (!(interactableComponent is null)) {
					var rotation = mainCamera.transform.rotation;
					interactionUI.transform.LookAt(transform.position + rotation * Vector3.forward,
						(rotation * Vector3.up) + new Vector3(0f, 20f, 0f));
					interactionUI.gameObject.SetActive(true);

					Logger.Log($"Found: {interactableComponent.gameObject.name}");
				} else if (!(interactableComponent is null)) {
					interactionUI.gameObject.SetActive(false);
				}
			}
		}


		private bool CheckForInteractableObject() {
			Ray ray = mainCamera.ViewportPointToRay(Vector3.one / InteractLength);


#if UNITY_EDITOR
			Debug.DrawRay(ray.origin, ray.direction * InteractLength, Color.yellow);
#endif


			return Physics.Raycast(ray, out hitResult, InteractLength);
		}

		public void OnInteraction(InputAction.CallbackContext context) {
			if (interactableComponent is null) {
				return;
			}

			interactableComponent.OnInteractionCompleted(gameObject);
		}


	}
}