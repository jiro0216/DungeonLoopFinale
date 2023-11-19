using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportDestination; // Set this in the Inspector to the destination where you want the player to teleport.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport the entire player GameObject (parent).
            other.transform.parent.position = teleportDestination.position;
        }
    }

}