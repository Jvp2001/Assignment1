using System;
using UnityEngine;

namespace Assignment1.FirstPersonCharacter {
	/// <summary>
	/// Allows the player to push <see cref="Rigidbody"/>ed <see cref="GameObject"/>s around the level.
	/// </summary>
	public class Pusher : MonoBehaviour {
		
		/// <summary>
		/// How fast you would like the player to be able to push RigidBody objects
		/// </summary>
		[Tooltip("How fast you would like the player to be able to push the object")]
		[SerializeField]
		private float pushPower = 250f;

		
		private void OnControllerColliderHit(ControllerColliderHit hit) {
			Rigidbody rigidbody = hit.rigidbody;
			if (rigidbody is null || rigidbody.isKinematic) {
				return;
			}
			Vector3 direction = transform.position - rigidbody.transform.position;
			
			rigidbody.AddForce(direction * pushPower);
		}
	}
}