// © 2020 Joshua Petersen. All rights reserved.

using Assignment1.Gameplay;
using InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


namespace Assignment1.FirstPersonCharacter
{
    /// <summary>
    ///<para>
    /// This script controls the character and allows the user to move around by using a keyboard.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Special Thanks to BlackCoffeeProd for his new video (<a href="https://youtu.be/gjy4Kp2AgM0">Here</a>) on how to make a first person character with the new input system.
    /// </para>
    /// <para>
    /// Special thanks to Brackeys First Person character video (<a href="https://youtu.be/_QajrabyTJc">Here</a>) which helped me implement jumping and ground detection.
    /// </para>
    /// </remarks>
    public class FirstPersonCharacterController : MonoBehaviour
    {
        private float movementX;
        private float movementY;
        [SerializeField] private CharacterController characterController;


        [SerializeField] [Header("Movement")] private float movementSpeed = 10f;

        [SerializeField] private float jumpHeight = 5f;

        [SerializeField] private InteractionComponent interactionComponent;

        public InteractionComponent InteractionComponent => interactionComponent;


        private void Start()
        {
            Logger.Log(GameplayManager.Instance.GameplaySettings.Difficulty.ToString());
        }

        private void Update()
        {
            MoveCharacter();
        }


        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 inputValue = context.ReadValue<Vector2>();
            movementX = inputValue.x;
            movementY = inputValue.y;
        }


        private void MoveCharacter()
        {
            Transform currentTransform = transform;
            Vector3 movement = currentTransform.right * movementX + currentTransform.forward * movementY;
            Logger.Log($"Movement: {movement}");
            characterController.Move(movement * (movementSpeed * Time.deltaTime));
        }
    }
}