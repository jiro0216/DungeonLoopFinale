using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class MainMenuManageScript : MonoBehaviour
{

    public void StartGame(){

        SceneManager.LoadScene("SampleScene");
    }
}
