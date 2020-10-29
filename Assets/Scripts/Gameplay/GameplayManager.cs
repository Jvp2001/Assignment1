// © 2020 Joshua Petersen. All rights reserved.
using System;
using System.Collections;
using System.Reflection.Emit;
using Gameplay;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UserInterface.Game;

namespace Assignment1.Gameplay
{
    [RequireComponent(typeof(CountdownTimer))]
    public class GameplayManager : Singleton<GameplayManager>
    {

        [SerializeField]
        private GameplaySettings gameplaySettings = new GameplaySettings();

        private bool displayEndOfGameMessage = false;
        private string endOfGameMessage = "Game Over!";

        private PlayerData playerData = new   PlayerData();
        private CountdownTimer timer;
        [SerializeField]
        private short numberOfGemsToWin = 5;


        public GameplaySettings GameplaySettings => gameplaySettings;

        public PlayerData PlayerData => playerData;

        public CountdownTimer Timer => timer;

        public short NumberOfGemsToWin => numberOfGemsToWin;

        private void Awake()
        {
            timer = GetComponent<CountdownTimer>();
            timer.CurrentTime = GameplaySettings.CountdownTime;
            timer.OnCountdownFinished += OnCountdownFinished;
            
            SceneManager.sceneLoaded += (scene, mode) =>
            {
                if (scene.name == "MainLevel")
                {
                    Logger.Log(PlayerHUD.Instance);
                    timer.Paused = false;

                }
            };

        }

        private void Start()
        {
            PlayerData.OnAmountCollectedChanged += CheckForGameCompletion;
        }

        private void OnGUI()
        {
            if (displayEndOfGameMessage)
            {
                GUIStyle style = new GUIStyle {fontSize = 50};
                GUI.Label(new Rect(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(600, 100)),
                    endOfGameMessage, style);
            }
        }

        private void CheckForGameCompletion(short value)
        {
            if (PlayerData.AmountCollected >= NumberOfGemsToWin)
            {
                StartCoroutine(nameof(GameCompleted));
            }
                
        }

        private IEnumerator GameCompleted() {
            yield return new WaitUntil(() =>PlayerData.AmountCollected >= NumberOfGemsToWin);
            StartCoroutine(nameof(GameFinished), "Game Completed!");
        }

        private IEnumerator GameFinished(string message) {
            FindObjectOfType<PlayerInput>().enabled = false;
            FindObjectOfType<PlayerHUD>().enabled = false;
            endOfGameMessage = message;
            displayEndOfGameMessage = true;
            yield return new WaitForSeconds(3);
            Cursor.visible = true;
            displayEndOfGameMessage = false;
            SceneManager.LoadScene("MainLevel");
        }

        private void OnCountdownFinished()
        {
            StartCoroutine(nameof(GameOver));
            
        }

        private IEnumerator GameOver()
        {
            yield return new WaitUntil(() => timer.CurrentTime < 1f);
            StartCoroutine(nameof(GameFinished), "Game Over!");
        }
    }
}