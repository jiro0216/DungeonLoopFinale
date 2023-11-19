using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScript : MonoBehaviour
{

    public GameObject otherGrid;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger is with the player
        if (other.CompareTag("Player"))
        {
            // Disable the visibility of the other grid
            
            otherGrid.SetActive(true);          
            Debug.Log("room 2 open");

            

             
        }
            
        
    }
}
