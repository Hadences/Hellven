using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void MovementInputEvent(UnityEngine.InputSystem.InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            float value = callbackContext.ReadValue<float>();
            //if the value is positive = RIGHT
            //if the value is negative = LEFT
            if(value == 1)
            {
                //RIGHT
                playerMovement.moveRight();
            }else if(value == -1)
            {
                //LEFT
                playerMovement.moveLeft();
            }

        }
    }
}
