// © 2020 Joshua Petersen. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using Assignment1.Animations.Handlers;
using Assignment1.AnimationSystem;
using DG.Tweening;
using UnityEngine;
using InteractionSystem;

namespace Assignment1.Triggers {

	[RequireComponent(typeof(TweenSequencer))]
	[RequireComponent(typeof(SequenceFinishedEventHandler))]
	public class AnimationTrigger : InteractableComponent {

		[SerializeField]
		private List<TweenSequencer> tweenSequencers;


		public HashSet<TweenSequencer> TweenSequencers => new HashSet<TweenSequencer>(tweenSequencers);

		private void Awake() {
			TweenSequencer itsOwnTweenSequencer = GetComponent<TweenSequencer>();
			if (!tweenSequencers.Contains(itsOwnTweenSequencer))
				tweenSequencers.Add(itsOwnTweenSequencer);
		}

		public override void OnInteractionCompleted(GameObject other) {
			Logger.Log("Interacted");
			foreach (TweenSequencer tweenSequencer in TweenSequencers) {
				tweenSequencer.Sequence.PlayForward();
				tweenSequencer.OnSequenceFinishedForward?.Invoke(tweenSequencer);
			}
		}
	}
}