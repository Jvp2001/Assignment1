using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = Assignment1.Logger;

namespace FirstPersonCharacter {
	[RequireComponent(typeof(Camera))]
	[RequireComponent(typeof(PlayerInput))]
	public class FirstPersonCameraController : MonoBehaviour {
		[SerializeField]
		private Transform characterBody = new RectTransform();


		[SerializeField]
		[Header("Mouse")]
		[Range(10f, 100f)]
		private float mouseSensitivity = 10.0f;

		private float xRotation;
		private float mouseX;
		private float mouseY;
		private Vector2 mousePosition;

		private float
			yRotation;

		private void Awake() {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Application.targetFrameRate = 60;
		}


		// Start is called before the first frame update
		void Start() {
		}

		private protected void Some() {
			
		}
		private void Update() {
			xRotation -= mouseY;
			yRotation += mouseX;
//			Logger.Log($"Camera Pos: ({mouseX}, {mouseY})");

			xRotation = Mathf.Clamp(xRotation, -90f, 90f);
			
			transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
			characterBody.Rotate(Vector3.up * mouseX);
			
		}


		public void OnLook(InputAction.CallbackContext context) {
			mousePosition = context.ReadValue<Vector2>();
			mouseX = mousePosition.x * mouseSensitivity * Time.deltaTime;
			mouseY = mousePosition.y * mouseSensitivity * Time.deltaTime;
		}
	}
}