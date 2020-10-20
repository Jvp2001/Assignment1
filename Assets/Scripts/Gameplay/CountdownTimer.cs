// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections;
using Assignment1.Gameplay;
using UnityEngine;

namespace Assignment1.Gameplay
{
    public delegate void CountdownFinished();
    public class CountdownTimer : MonoBehaviour
    {
        public event CountdownFinished OnCountdownFinished;
        public float CurrentTime { get; set; }

        public bool Paused { get; set; } = true; 
        

        public CountdownTimer(TimerOptions startTime)
        {
            CurrentTime = startTime.Minutes * 60 + startTime.Seconds;
        }

        public void Start()
        {
            StartCoroutine("UpdateTimer");
        }

        private IEnumerator UpdateTimer()
        {
            while (!Paused && CurrentTime > 0.0f) 
            {
                yield return new WaitForSecondsRealtime(1.0f);
                Logger.Log($"ELLAPSED TIME: {CurrentTime}");
                --CurrentTime;
            }
            OnCountdownFinished?.Invoke();
        }

        public override string ToString()
        {
            float seconds = CurrentTime % 60;
            return $@"{Mathf.Floor(CurrentTime / 60.0f) }:{ (seconds < 10 ? "0" : "" )}{ seconds }";
        }
    }
}