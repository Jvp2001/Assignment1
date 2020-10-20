// © 2020 Joshua Petersen. All rights reserved.
﻿using System;
using System.Collections.Generic;
using InteractionSystem;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


namespace InteractionSystem {
	public class InteractableComponent : MonoBehaviour {

		[SerializeField]
		private string interactMessageText;

		[Serializable]
		protected class OnInteractedUnityEvent : UnityEvent<GameObject> {
			
		}

		[SerializeField]
		private OnInteractedUnityEvent onInteracted;

		protected OnInteractedUnityEvent OnInteracted => onInteracted;
		// Start is called before the first frame update
		
		void Start() {

		}


		public void OnInteractionCompleted(GameObject other) {
			if (other is null) {
				return;
			}
			
			if (onInteracted.GetPersistentEventCount() > 0) {
				onInteracted.Invoke(other);
			}
			
		}


		public virtual bool BeingLookedAt => true;
	}

}