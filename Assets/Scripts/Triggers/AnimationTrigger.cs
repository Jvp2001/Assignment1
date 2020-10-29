// © 2020 Joshua Petersen. All rights reserved.

using System;
using System.Collections;
using Assignment1.Animations.Handlers;
using Assignment1.AnimationSystem;
using DG.Tweening;
using UnityEngine;
using InteractionSystem;

namespace Assignment1.Triggers {
	
	[RequireComponent(typeof(TweenSequencer))]
	[RequireComponent(typeof(SequenceFinishedEventHandler))]
	public class AnimationTrigger : InteractableComponent {

		private TweenSequencer tweenSequencer;

		public TweenSequencer TweenSequencer => tweenSequencer;

		private void Awake() {
			tweenSequencer = GetComponent<TweenSequencer>();
		}

		public override void OnInteractionCompleted(GameObject other) {
			Logger.Log("Interacted");
			tweenSequencer.Sequence.PlayForward();
			tweenSequencer.OnSequenceFinishedForward?.Invoke(tweenSequencer);
		}
	}
}