using Assignment1.AnimationSystem;
using UnityEngine;

namespace Assignment1.Animations.Handlers
{
    public class SequenceFinishedEventHandler : MonoBehaviour
    {
        [SerializeField] private Gem gem;

        public Gem Gem => gem;

        public virtual void OnSequencedFinished(TweenSequencer sequencer) {
            Gem.CanPickup = true;
        }
    }
}