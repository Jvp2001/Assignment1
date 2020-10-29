using System;
using System.Collections;
using System.Collections.Generic;
using Assignment1.AnimationSystem;
using Assignment1.Gameplay;
using UnityEditor.SceneManagement;
using UnityEngine;
using Logger = Assignment1.Logger;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(SphereCollider))]
public class Gem : MonoBehaviour {

	[SerializeField]
	private AudioClip pickupSound;

	private AudioSource audioSource;
	private AudioSource currentAudioSorce;
	private MeshRenderer pickupMesh;
	private SphereCollider sphereCollider;
	private TweenSequencer tweenSequencer;


	public bool CanPickup {
		get => gameObject.activeSelf;
		set => gameObject.SetActive(value);
	}

	private void Start() {
		CanPickup = false;
	}

	private void OnEnable() {
		sphereCollider = GetComponent<SphereCollider>();
		pickupMesh = GetComponent<MeshRenderer>();
	}

	private void OnTriggerEnter(Collider other) {
		Logger.Log("Collided with player!");
		Logger.Log($"Other tag: {other.tag}");
		if (other.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(pickupSound, other.transform.position);
			++GameplayManager.Instance.PlayerData.AmountCollected;
			Destroy(this);
		}
		
	}

	public void OnCollected(TweenSequencer sequencer) {
		gameObject.SetActive(false);
		
	}
}