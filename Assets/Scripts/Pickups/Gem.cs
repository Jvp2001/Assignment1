using Assignment1.Gameplay;
using UnityEngine;

namespace Assignment1.Pickups {

	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(SphereCollider))]
	public class Gem : MonoBehaviour {

		[SerializeField]
		private AudioClip pickupSound;

		[SerializeField]
		private bool autoPickup;
		
		private SphereCollider sphereCollider;


		public bool IsTrigger {
			get => sphereCollider.isTrigger ;
			set => sphereCollider.isTrigger = value;
		}

		private void Awake() {
			sphereCollider = GetComponent<SphereCollider>();
			sphereCollider.isTrigger = autoPickup;
		}

	
		private void OnTriggerStay(Collider other) {
			if (!autoPickup) {
				return;
			}

			Logger.Log("Collided with player!");
			Logger.Log($"Other tag: {other.tag}");
			if (other.CompareTag("Player") && autoPickup) {
				AudioSource.PlayClipAtPoint(pickupSound, other.transform.position);
				++GameplayManager.Instance.PlayerData.AmountCollected;
				Destroy(gameObject);
			}
		}

		public void Collect(GameObject other) {
			autoPickup = true;
		}
	}
}