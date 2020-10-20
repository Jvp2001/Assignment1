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
    /// This script controls the character and allows the user to move around and jump using the keyboard.
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
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonCharacterController : MonoBehaviour
    {
        private float movementX;
        private float movementY;

        private CharacterController characterController;

        private bool canJump = false;

        private Vector3 velocity;

        [Header("Physics")] [SerializeField] private float gravity = -9.81f;

        /// <summary>
        /// <para>
        /// The distance (radius of the sphere) to the ground.
        /// </para>
        /// </summary>
        [FormerlySerializedAs("groundCheckRadius")]
        [SerializeField]
        [Tooltip(
            "The distance (radius of the sphere) to the ground. The higher the value means the greater the distance you will counted as being on the ground.")]
        private float groundCheckDistance = 0.4f;

        /// <summary>
        /// <para>
        /// The layer (tag) that is used to represent the ground.
        /// </para>
        /// </summary>
        [SerializeField]
        [Tooltip("The layer that is used to represent the ground.")]
        private LayerMask groundMask;

        /// <summary>
        /// <para>
        /// The Ground Check GameObject's transform is used to draw the Sphere which will check if the character is on the ground.
        /// </para>
        /// </summary>
        [SerializeField]
        [Tooltip(
            "The Ground Check GameObject's transform is used to draw the Sphere which will check if the character is on the ground.")]
        private Transform groundCheck = new RectTransform();


        [SerializeField] [Header("Movement")] private float movementSpeed = 10f;

        [SerializeField] private float jumpHeight = 5f;

        private InteractionComponent interactionComponent;

        public InteractionComponent InteractionComponent => interactionComponent;

        public Vector3 Velocity => velocity;

        public bool IsGrounded => Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        public bool CanJump => canJump;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            interactionComponent = GetComponent<InteractionComponent>();
        }

        private void Start()
        {
            Logger.Log(GameplayManager.Instance.GameplaySettings.Difficulty.ToString());
        }

        private void Update()
        {
            MoveCharacter();
        }

        private void FixedUpdate()
        {
            UpdatePhysics();
        }

        void UpdatePhysics()
        {
            if (IsGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
                canJump = true;
            }

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 inputValue = context.ReadValue<Vector2>();
            movementX = inputValue.x;
            movementY = inputValue.y;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (CanJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                Logger.Log("Jumped!");
                canJump = false;
            }
        }


        private void MoveCharacter()
        {
            Transform currentTransform = transform;
            Vector3 movement = currentTransform.right * movementX + currentTransform.forward * movementY;
            Logger.Log($"Movement: {movement}");
            characterController.Move(movement * movementSpeed * Time.deltaTime);
        }
    }
}