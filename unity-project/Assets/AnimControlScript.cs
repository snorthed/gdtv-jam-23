using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using Helpers;

namespace Player
{


    public class AnimControlScript : MonoBehaviour , PlayerInput.IPlayerActions
    {
        
        bool isRunning;
        bool isAiming;
        bool isPunching;
        bool isSmashing;
        bool isDodging;
        Vector2 currentLookPosition;
        Vector2 currentMoveInput;
        Vector2 directionCurrentMove;
        PlayerController playerController;
        [SerializeField]Animator playerAnimator;
        
        public void OnDodge(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            isDodging = true ;

        }

        public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            currentLookPosition = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
        }

        public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            currentMoveInput = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
        }

        public void OnPrimary(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnSecondary(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnPrimaryCancel(InputAction.CallbackContext obj) {
            
        }
        public void OnSecondaryCancel(InputAction.CallbackContext obj)
        {

        }


        private void Awake()
        {
            
            playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            
            directionCurrentMove = currentMoveInput.normalized - currentLookPosition.normalized;
            
            playerAnimator.SetFloat("moveX", directionCurrentMove.x);
            playerAnimator.SetFloat("moveY", directionCurrentMove.y);
            
        }
    }
}

