using DG.Tweening;
using UnityEngine;

namespace Assignment1.Animations
{
    public class GameplayStatesHandler : MonoBehaviour, IGameplayStates
    {
        private TweenSequencer tweenSequencer;

        public void OnSequenceFinished(TweenSequencer tweenSequencer)
        {
            this.tweenSequencer = tweenSequencer;
            gameObject.GetComponentInChildren<Gem>().CanPickup = true;


        }
        
  
        public void OnGemCollected()
        {
          tweenSequencer.Reverse(0.2f);  
          
        }
    }
}