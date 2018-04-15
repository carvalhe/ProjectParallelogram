using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    /**
     * Contains the directions that the player can be facing at any one time.
     */
    public enum PlayerDirection
    {
        UpDirection,
        DownDirection,
        LeftDirection,
        RightDirection
    }

    /* The PlayerController script used to move the player. */
    PlayerController playerController;

    /* The current directional state of the player. */
    PlayerDirection playerDirection;

    /**
     * Initialize member variables.
     */
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerDirection = PlayerDirection.UpDirection;
    }

    /**
     * Updates the player's status once a frame.
     */
    void Update()
    {
        UpdateMovementInput();
    }

    /**
     * Updates the player's movement.
     */
    void UpdateMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log("Horizontal: " + horizontalInput + " Vertical: " + verticalInput);

        /* 
         * Determine based on the horizontal and vertical inputs which direction 
         * the player should be in. Note: The player shouldn't be able to move
         * if more than one direction key is pressed.
         */
        if (horizontalInput == 0.0f || verticalInput == 0.0f)
        {
            Quaternion newRotation;
            
            /* Horizontal input detected. */
            if (horizontalInput != 0.0f)
            {
                if (horizontalInput == -1.0f)
                {
                    playerDirection = PlayerDirection.LeftDirection;

                    /* Means to rotate around z-axis by 90 degrees counterclockwise. */
                    newRotation = Quaternion.Euler(Vector3.forward * 90.0f);
                }
                else
                {
                    playerDirection = PlayerDirection.RightDirection;
                    newRotation = Quaternion.Euler(Vector3.forward * -90.0f);
                }

                /* Only send updates to the controller if the direction changed. */
                playerController.UpdateDirection(newRotation);
            }

            /* Vertical input detected. */
            else if (verticalInput != 0.0f)
            {
                if (verticalInput == -1.0f)
                {
                    playerDirection = PlayerDirection.DownDirection;
                    newRotation = Quaternion.Euler(Vector3.forward * 180.0f);
                }
                else
                {
                    playerDirection = PlayerDirection.UpDirection;
                    newRotation = Quaternion.Euler(Vector3.forward);
                }

                playerController.UpdateDirection(newRotation);
            }
        }
    }

    /**
     * Getter for the player's current direction.
     * 
     * @return The direction of the player.
     */
    public PlayerDirection GetPlayerDirection()
    {
        return playerDirection;
    }
}
