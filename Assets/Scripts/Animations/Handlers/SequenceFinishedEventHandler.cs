using Assignment1.AnimationSystem;
using UnityEngine;
using Assignment1.Pickups;
namespace Assignment1.Animations.Handlers
{
    public class SequenceFinishedEventHandler : MonoBehaviour
    {
        [SerializeField] private Gem gem;

        public Gem Gem => gem;

        public virtual void OnSequencedFinished(TweenSequencer sequencer) {
            Gem.IsActive = true;
        }
    }
}