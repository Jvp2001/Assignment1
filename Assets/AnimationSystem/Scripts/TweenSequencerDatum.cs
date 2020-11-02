// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Assignment1.AnimationSystem {

	/// <summary>
	/// A wrapper around the <see cref="TweenDatum"/> Class.
	/// </summary>
	[Serializable]
	public class TweenSequencerDatum {
		[SerializeField]
		private TweenDatum tweenDatum;

		/// <summary>
		   /// The transform of the <see cref="GameObject"/> we want to animate.
		   /// </summary>
		[SerializeField]
		private Transform objectToTween;

		public TweenType TweenType => tweenDatum.TweenType;

		public Transform ObjectToTween => objectToTween;

		public Vector3 PositionOffset => tweenDatum.PositionOffset;

		public float Duration => tweenDatum.Duration;

		public Vector3 TargetRotation => tweenDatum.TargetRotation;
		public bool Join => tweenDatum.Join;

		public bool AnimateLocally => tweenDatum.AnimateLocally;
		
		/// <summary>
		/// Creates a <see cref="Tween"/> based on the of <see cref="TweenType"/>
		/// </summary>
		/// <seealso cref="TweenSequencer.BuildSequence"/>
		public Tween Tween {
			get {
				
				switch (TweenType) {
					case TweenType.Move:
							Vector3 distance = objectToTween.transform.position + PositionOffset;
						if (AnimateLocally) {
							return ObjectToTween.DOLocalMove(distance, Duration);
						}

							return ObjectToTween.DOMove(distance, Duration);
					case TweenType.Rotate:
						if(AnimateLocally)
							return ObjectToTween.DOLocalRotate(TargetRotation, Duration);
						return ObjectToTween.DORotate(TargetRotation, Duration);
				}

				return null;
			}
		}
	}
}