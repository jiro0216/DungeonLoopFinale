using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverContinueScript : MonoBehaviour
{
    public GameObject GameOverPanel;


    private void Update()
    {
        Continue();
    }
    private void Start()
    {
        GameOverPanel.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger is with the player
        if (other.CompareTag("Player"))
        {
            // Disable the visibility of the other grid
            GameOverPanel.SetActive(true);
            Debug.Log("Trigger detected with player. Other grid disabled.");
        }
    }

    // Call this function when the player decides to continue (e.g., by clicking a button)
    public void Continue()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameOverPanel.SetActive(false);

        }
    }
}
