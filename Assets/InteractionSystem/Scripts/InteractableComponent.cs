// © 2020 Joshua Petersen. All rights reserved.

using System;
using System.Collections.Generic;
using InteractionSystem;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Logger = Assignment1.Logger;


namespace InteractionSystem
{
    public class InteractableComponent : MonoBehaviour
    {

        [SerializeField] private OnInteractedUnityEvent onInteracted;

        protected OnInteractedUnityEvent OnInteracted => onInteracted;


        void Start()
        {
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }

        public virtual void OnInteractionCompleted(GameObject other)
        {
            Logger.Log("Interacted"); 
            onInteracted?.Invoke(other);
            DestroyImmediate(this);
        }

        [Serializable]
        protected class OnInteractedUnityEvent : UnityEvent<GameObject>
        {}
    }
}