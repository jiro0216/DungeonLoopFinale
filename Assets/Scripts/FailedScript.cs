using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger is with the player
        if (other.CompareTag("Player"))
        {
            // Disable the visibility of the other grid
            
            Debug.Log("failed");
            Application.Quit();
        }
    }

}
