using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerController : MonoBehaviour
{
    Transform playerTransform;

    /**
     * Initialize components for the PlayerController script.
     */
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    /**
     * Updates the direction of the player.
     * 
     * @param newRotation The new rotation that the player's transform should be
     * set to.
     */
    public void UpdateDirection(Quaternion newRotation)
    {
        playerTransform.transform.rotation = newRotation;
    }
}
