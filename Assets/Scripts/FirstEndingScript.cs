using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class FirstEndingScript : MonoBehaviour
{
    public Transform teleportDestination;
    public string playerTag = "Player"; // Tag of the player object

    private void Update()
    {
        // You can remove this method from the Update since you are calling it from the button click event.
    }

    // Method to be called when the button is clicked
    public void TeleportPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            playerObject.transform.position = teleportDestination.position;
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the correct tag.");
        }
    }
}
