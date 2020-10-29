using System;
using UnityEngine.Events;

namespace Assignment1.AnimationSystem
{
    [Serializable]
    public class SequenceFinishedEvent : UnityEvent<TweenSequencer>
    {}
}
