using System;
using UnityEngine;

namespace Assignment1.Gameplay
{
    [Serializable]
    public class GameplaySettings
    {
        public static readonly Difficulty[] Difficulties = {Difficulty.Easy, Difficulty.Normal, Difficulty.Hard};
        public Difficulty Difficulty { get; set; } = Difficulty.Normal;

        [SerializeField] private TimerOptions easyTime = new TimerOptions(2,30);
        [SerializeField] private TimerOptions normalTime = new TimerOptions(1, 45);
        [SerializeField] private TimerOptions hardTime = new TimerOptions(1,45);


        public TimerOptions EasyTime => easyTime;

        public TimerOptions NormalTime => normalTime;

        public TimerOptions HardTime => hardTime;


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

        public GameplaySettings()
        {
        }
    }
}