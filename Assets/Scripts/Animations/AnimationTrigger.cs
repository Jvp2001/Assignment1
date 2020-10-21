// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Assignment1.Animations {
	[RequireComponent(typeof(TweenSequencer))]
	public class AnimationTrigger  : InteractionSystem.InteractableComponent {

		private TweenSequencer tweenSequencer;

		public TweenSequencer TweenSequencer => tweenSequencer;

		private void Awake() {
			tweenSequencer = GetComponent<TweenSequencer>();
			
		}

		public override void OnInteractionCompleted(GameObject other)
		{
			Logger.Log("Interacted");
			tweenSequencer.Sequence.PlayForward();
			other.GetComponent<IGameplayStates>()?.OnSequenceFinished(tweenSequencer);
		}
	}
}