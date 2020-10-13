using System;
using DG.Tweening;
using UnityEngine;

namespace Assignment1.Animations {

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

		/// <summary>
		/// Creates a <see cref="Tween"/> based on the of <see cref="TweenType"/>
		/// </summary>
		/// <seealso cref="TweenSequencer.BuildSequence"/>
		public Tween Tween {
			get {
				
				switch (TweenType) {
					case TweenType.Move:
						return ObjectToTween.DOMove(ObjectToTween.transform.position + PositionOffset, Duration);
					case TweenType.Rotate:
						return ObjectToTween.DORotate(TargetRotation, Duration);
				}

				return null;
			}
		}


	}
}