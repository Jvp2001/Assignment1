using System;
using DG.Tweening;
using UnityEngine;

namespace Assignment1.Animations {
	/// <summary>
	/// This Scriptable object is used by the <see cref="TweenSequencer"/> to animate <see cref="GameObject"/>s. 
	/// </summary>
	[Serializable]
	[CreateAssetMenu(fileName = "TweenDatum", menuName = "Tween/TweenDatum")]
	public class TweenDatum : ScriptableObject {


		[SerializeField]
		private TweenType tweenType;


		[SerializeField]
		private Vector3 positionOffset;

		[SerializeField]
		private float duration = 1f;

		[SerializeField]
		private Vector3 targetRotation;

		[SerializeField]
		private bool join = true;

		/// <summary>
		/// This is the type of animation you want to apply to a <see cref="GameObject"/>
		/// </summary>
		public TweenType TweenType => tweenType;

		/// <summary>
		///  This means will the Sequencer play the animations simultaneously or one after the other.
		/// This is true by default, due to me needing to animate in pairs due to the my assets. For example, a drawer and its handle are separate.
		/// </summary>
		public Vector3 PositionOffset => positionOffset;

		/// <summary>
		/// This <see cref="Vector3"/> is used to  offset a <see cref="GameObject"/>'s local position.
		/// This is only used when <see cref="tweenType"/> is set to move.  
		/// </summary>
		public float Duration => duration;

		/// <summary>
		/// This is how long the animation will play for, in seconds. 
		/// </summary>
		public Vector3 TargetRotation => targetRotation;

		/// <summary>
		/// This <see cref="Vector3"/> is used to  offset a <see cref="GameObject"/>'s local rotation.
		/// This is only used when <see cref="tweenType"/> is set to Rotate. 
		/// </summary>
		public bool Join => join;


	}

}