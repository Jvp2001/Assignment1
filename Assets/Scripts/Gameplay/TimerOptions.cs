using System;
using UnityEngine;

namespace Assignment1.Gameplay
{
    [Serializable]
    public class TimerOptions
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

        public static implicit operator float(TimerOptions timerOptions)
        {
            return timerOptions.Minutes * 60f + timerOptions.Seconds;
        }
    }
}