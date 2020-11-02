using System;
using System.Collections;
using System.Collections.Generic;
using Assignment1.AnimationSystem;
using Assignment1.Gameplay;
using UnityEditor.SceneManagement;
using UnityEngine;
using Logger = Assignment1.Logger;

namespace Assignment1.Pickups {

	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(SphereCollider))]
	
	public class Gem : MonoBehaviour {

		[SerializeField]
		private AudioClip pickupSound;

		[SerializeField]
		private bool autoPickup = true;
		private AudioSource audioSource;
		private AudioSource currentAudioSource;
		private TweenSequencer tweenSequencer;

	
		public bool IsActive {
			get => gameObject.activeSelf;
			set => gameObject.SetActive(value);
		}
		private void Start() {
			IsActive = !autoPickup;
		}
		
		private void OnTriggerStay(Collider other)
		{
			if (!autoPickup) {
				return;
			}
			Logger.Log("Collided with player!");
			Logger.Log($"Other tag: {other.tag}");
			if (other.CompareTag("Player")) {
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