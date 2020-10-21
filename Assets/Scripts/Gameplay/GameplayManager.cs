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
        private CountdownTimer timer;

        private PlayerData playerData = new   PlayerData();     
        private string endoOfGameMessage = "Game Over!";
        private bool displayEndOfGameMessage = false;
        
        [SerializeField]
        private GameplaySettings gameplaySettings = new GameplaySettings();

    
        public GameplaySettings GameplaySettings => gameplaySettings;

        public PlayerData PlayerData => playerData;

        public CountdownTimer Timer => timer;

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

        private void OnCountdownFinished()
        {
            StartCoroutine(nameof(GameOver));
            
        }

        private IEnumerator GameOver()
        {
            yield return new WaitUntil(() => timer.CurrentTime < 1f);
            FindObjectOfType<PlayerInput>().enabled = false;
            GameObject.Find("PlayerHUD").SetActive(false);
            displayEndOfGameMessage = true;
            yield return new WaitForSeconds(3);
            displayEndOfGameMessage = false;
            Cursor.visible = true;
            SceneManager.LoadScene("MainMenuScene");
        }

        private void OnGUI()
        {
            if (displayEndOfGameMessage)
            {
                GUIStyle style = new GUIStyle {fontSize = 50};
                GUI.Label(new Rect(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(600, 100)),
                    endoOfGameMessage, style);
            }
        }
    }
}