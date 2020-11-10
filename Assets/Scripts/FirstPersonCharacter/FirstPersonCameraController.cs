// © 2020 Joshua Petersen. All rights reserved.

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = Assignment1.Logger;

namespace Assignment1.FirstPersonCharacter {

	/// <summary>
	/// Controls the camera via mouse movement to make the character move base on the camera rotation. 
	/// </summary>
	/// <remarks>
	/// Special thanks to djc51401 (see https://forum.unity.com/threads/new-input-system-fps-script-help.906197) for sharing his fix for first person camera movement, using the new input system. 
	/// </remarks>
	[RequireComponent(typeof(Camera))]
	[RequireComponent(typeof(PlayerInput))]
	public class FirstPersonCameraController : MonoBehaviour {
		[SerializeField]
		private Transform characterBody;

		[SerializeField]
		private Camera mainCamera;

		[SerializeField]
		[Header("Mouse")]
		[Range(10f, 100f)]
		private float mouseSensitivity = 10.0f;

		private float lookX;
		private float lookY;


		private void Awake() {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			
		}


		private void Update() {
			lookY = Mathf.Clamp(lookY, -90f, 90f);
			characterBody.localEulerAngles = new Vector3(0f, lookX, 0f);
			mainCamera.transform.localEulerAngles = new Vector3(lookY, 0f, 0f);
		}


		public void OnLook(InputAction.CallbackContext context) {
			Vector2 mousePosition = context.ReadValue<Vector2>();
			lookX += mousePosition.x * mouseSensitivity * Time.deltaTime;
			lookY += mousePosition.y * mouseSensitivity * Time.deltaTime;
		}
	}
}
