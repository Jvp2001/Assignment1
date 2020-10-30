// © 2020 Joshua Petersen. All rights reserved.
using System;
using UnityEngine;

namespace Assignment1.Gameplay
{
    /// <summary>
    /// Controls how much time you have to complete the game. 
    /// </summary>
    [Serializable]
    public class GameplaySettings
    {
        /// <summary>
        /// This array is used by the <see cref="Assignment1.UserInterface.Controllers.GameplaySettingsMenuController"/>to list the different difficulties. 
        /// </summary>
        
        public static readonly Difficulty[] Difficulties = {Difficulty.Easy, Difficulty.Normal, Difficulty.Hard};

        [SerializeField] private TimerOptions easyTime = new TimerOptions(2,30);
        [SerializeField] private TimerOptions normalTime = new TimerOptions(1, 45);
        [SerializeField] private TimerOptions hardTime = new TimerOptions(1,15);

        public GameplaySettings()
        {
        }

        public Difficulty Difficulty { get; set; } = Difficulty.Normal;


        public TimerOptions EasyTime => easyTime;

        public TimerOptions NormalTime => normalTime;

        public TimerOptions HardTime => hardTime;
        
        /// <summary>
        /// Returns the amount of time the user has to complete the level, based ot the <see cref="Difficulty"/> they selected. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> If they choose a enum value that is accounted for, unlikely to every be thrown, since I have been exhaustive with this enum. </exception>
        public TimerOptions CountdownTime
        {
            get
            {
                switch (Difficulty)
                {
                    case Difficulty.Easy:
                        return easyTime;
                    case Difficulty.Normal:
                        return normalTime;
                    case Difficulty.Hard:
                        return hardTime;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}