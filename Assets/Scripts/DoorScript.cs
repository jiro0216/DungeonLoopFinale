using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject otherGrid;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger is with the player
        if (other.CompareTag("Player"))
        {
            // Disable the visibility of the other grid
            otherGrid.SetActive(false);
            Debug.Log("Trigger detected with player. Other grid disabled.");


        }
    }
}
