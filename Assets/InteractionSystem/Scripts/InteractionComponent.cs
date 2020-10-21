// © 2020 Joshua Petersen. All rights reserved.
 using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
 using UnityEngine.Serialization;
 using UserInterface.Game.Interaction;
using Logger = Assignment1.Logger;

namespace InteractionSystem {

	public class InteractionComponent : MonoBehaviour {

		[SerializeField]
		private float interactLength = 50.0f;

		private RaycastHit hitResult;

		private InteractableComponent interactableComponent;
		private Camera mainCamera;
		private InteractionUI interactionUI;
		private Vector2 mousePosition = Vector2.zero;
		private Transform parantTransform;

		private Vector3 MousePositionInWorld => mainCamera.ScreenToWorldPoint(mousePosition);

		// Start is called before the first frame update
		void Start() {
			parantTransform = gameObject.GetComponentInParent<Transform>();
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
				Logger.Log($"Hit Object: {hitObject.name}");
				interactableComponent = hitObject.GetComponent<InteractableComponent>();
				if (!(interactableComponent is null)) {
					var rotation = mainCamera.transform.rotation;
					interactionUI.transform.LookAt(transform.position + rotation * Vector3.forward,
						(rotation * Vector3.up) + new Vector3(0f, 20f, 0f));
					interactionUI.gameObject.SetActive(true);

					Logger.Log($"Found: {interactableComponent.gameObject.name}");
				} else if (interactableComponent is null) {
					interactionUI.gameObject.SetActive(false);
				}
			}
		}

		public void OnLook(InputAction.CallbackContext context)
		{
			mousePosition += context.ReadValue<Vector2>();
		}
		
		private bool CheckForInteractableObject() {
			var mainCameraTransform = mainCamera.transform;
			Ray ray = new Ray(mainCameraTransform.position, mainCameraTransform.forward);
			
#if UNITY_EDITOR
			Debug.DrawLine(MousePositionInWorld, MousePositionInWorld  * interactLength, Color.red);
#endif


			return Physics.Raycast(ray, out hitResult, interactLength);
		}

		public void OnInteraction(InputAction.CallbackContext context) {
			interactableComponent?.OnInteractionCompleted(gameObject);
		}


	}
	
	
}