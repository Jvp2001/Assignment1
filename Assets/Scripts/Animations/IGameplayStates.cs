namespace Assignment1.Animations
{
    public interface IGameplayStates
    {
        void OnSequenceFinished(TweenSequencer tweenSequencer);

        /// <summary>
        /// This will always be called after <see cref="OnSequenceFinished"/>.
        /// </summary>
        void OnGemCollected();
    }
}