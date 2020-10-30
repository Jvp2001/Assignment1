// © 2020 Joshua Petersen. All rights reserved.
using System;
using UnityEngine;

namespace Assignment1.Gameplay
{
    /// <summary>
    /// Store the number of minutes and seconds you have to complete the game.
    /// Used in <see cref="GameplaySettings"/> with <see cref="Difficulty"/> to control how much time the user has to complete the game. 
    /// </summary>
    [Serializable]
    public struct TimerOptions
    {
        [SerializeField] private short minutes;
        [SerializeField] private short seconds;

        public TimerOptions(short minutes, short seconds)
        {
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public short Minutes
        {
            get => minutes;
        }

        public short Seconds
        {
            get => seconds;
        }

        /// <summary>
        /// Just converts the minutes and seconds into a float. This is used in the <see cref="CountdownTimer"/> class. 
        /// </summary>
        /// <param name="timerOptions">The timer options you want to convert to a float.</param>
        /// <returns></returns>
        public static implicit operator float(TimerOptions timerOptions)
        {
            return timerOptions.Minutes * 60f + timerOptions.Seconds;
        }
    }
}