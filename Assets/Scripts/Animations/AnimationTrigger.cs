// © 2020 Joshua Petersen. All rights reserved.
using System;
using UnityEngine;

namespace Assignment1.Animations {
	[RequireComponent(typeof(TweenSequencer))]
	public class AnimationTrigger  : InteractionSystem.InteractionComponent {

		private TweenSequencer tweenSequencer;

		public TweenSequencer TweenSequencer => tweenSequencer;

		private void Awake() {
			tweenSequencer = GetComponent<TweenSequencer>();
		}

	}
}