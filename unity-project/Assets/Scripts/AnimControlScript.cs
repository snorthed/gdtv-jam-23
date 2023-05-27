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
        bool isShooting;
        public bool isCurrentWeaponRanged;
        Vector2 currentLookPosition;
        Vector2 currentMoveInput;
        Vector2 directionCurrentMove;
        PlayerController playerController;
        [SerializeField]Animator playerAnimator;
        
        public void OnDodge(InputAction.CallbackContext context)
        {
            isDodging = true ;

        }

        public void OnLook(InputAction.CallbackContext context)
        {
            currentLookPosition = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            playerAnimator.SetBool("isRunning", true);
            currentMoveInput = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
        }

        public void OnPrimary(InputAction.CallbackContext context)
        {
            
            if (playerController._currentWeapon == playerController.weapons[0])
            {
                playerAnimator.SetTrigger("primaryRangedShot");
                
            }
            else
            {
                playerAnimator.SetInteger("primaryMeleePunchVaration", Random.Range(1, 3));
                playerAnimator.SetTrigger("primaryMeleePunch");
            }
        }

        public void OnSecondary(InputAction.CallbackContext context)
        {
            if (playerController._currentWeapon == playerController.weapons[0])
            {
                playerAnimator.SetTrigger("isHolding");
                playerAnimator.ResetTrigger("isThrowing");
            }
            else
            {
                playerAnimator.SetTrigger("isHoldingMelee");
                playerAnimator.ResetTrigger("isExplodingMelee");
            }
                
           
        }
        public void OnSwapWeapon(InputAction.CallbackContext context)
        {
            Debug.Log("Weapon Swap animation should happen");
            if (playerController._currentWeapon == playerController.weapons[0])
            {
                playerAnimator.SetBool("isMelee", true);
            }
            else
            {
                playerAnimator.SetBool("isMelee",false);
            }
        }

        public void OnPrimaryCancel(InputAction.CallbackContext obj)
        {
            if (playerController._currentWeapon == playerController.weapons[0])
            {
                playerAnimator.ResetTrigger("primaryRangedShot");

            }
            else
            {
                
                playerAnimator.ResetTrigger("primaryMeleePunch");
            }
        }
        public void OnSecondaryCancel(InputAction.CallbackContext obj)
        {
            if (playerController._currentWeapon == playerController.weapons[0])
            {
                playerAnimator.ResetTrigger("isHolding");
                playerAnimator.SetTrigger("isThrowing");
            }
            else
            {
                playerAnimator.ResetTrigger("isHoldingMelee");
                playerAnimator.SetTrigger("isExplodingMelee");
                
            }
        }
        

        private void Awake()
        {
            
            playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            
            directionCurrentMove = currentMoveInput.normalized - currentLookPosition.normalized;
            if (currentMoveInput == Vector2.zero)
            {
                playerAnimator.SetBool("isRunning", false);
            }
            playerAnimator.SetFloat("moveX", directionCurrentMove.x);
            playerAnimator.SetFloat("moveY", directionCurrentMove.y);
            
        }

        
    }
}

