// © 2020 Joshua Petersen. All rights reserved.
using System;
using DG.Tweening;
using UnityEngine;

namespace Assignment1.Animations {
/// <summary>
/// Allows me to setup reusable animations in the inspector
/// https://youtu.be/iuPi8Zhex50
/// <seealso cref="DOTween"/>
/// </summary>
	public class TweenSequencer : MonoBehaviour {

		[SerializeField]
		private TweenSequencerDatum[] tweenData;

		private Sequence sequence;

		private void Awake() {
			sequence = DOTween.Sequence();
			BuildSequence();
		}

		
		private void BuildSequence() {
			sequence.Pause();
			sequence.SetAutoKill(false);
			foreach (TweenSequencerDatum tweenDatum in tweenData) {
				if (tweenDatum.Join) {
					sequence.Join(tweenDatum.Tween);
				} else {
					sequence.Append(tweenDatum.Tween);
				}
			}
		}
#if UNITY_EDITOR
		
		/// <summary>
		/// Adds a button to the inspector so I can test it out while I am in game. 
		/// </summary>
		[UnityEditor.CustomEditor(typeof(TweenSequencer))]
		class TweenSequencerEditor : UnityEditor.Editor {
			private TweenSequencer tweenSequencer;

			private void OnEnable() {
				tweenSequencer = (TweenSequencer) target;
			}

			public override void OnInspectorGUI() {
				base.OnInspectorGUI();
				if(GUILayout.Button(new GUIContent("Preview", "Play The animation")))
				{
					tweenSequencer.PreviewAnimation();
					
				}
			}
		}
		
		private bool playSequenceFromStart = true;

		private void PreviewAnimation() {
			if (playSequenceFromStart) {
				sequence.PlayForward();
			} else {
				sequence.PlayBackwards();
			}

			playSequenceFromStart = !playSequenceFromStart;
		}
#endif
	
		private void OnDestroy() {
			sequence.Kill();
		}
	}
	
	

}