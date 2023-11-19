using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    private Story currentStory;
    public bool DialogueIsPlaying { get; private set; }

    private Coroutine displayLineCoroutine;

    private bool canContinueToNextLine = false;

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // Get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!DialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(1f);
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        Debug.Log("Dialogue ended.");
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // Set text for the current dialogue line
            if (displayLineCoroutine != null) { 
            
                StopCoroutine(displayLineCoroutine);
            
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            DisplayChoices();
      
           // Display choices, if any, for this dialogue line

        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private IEnumerator DisplayLine(string line)
    {

        dialogueText.text = "";

        canContinueToNextLine = false; 


        foreach (char letter in line.ToCharArray()) {

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        canContinueToNextLine = true;
    }


    private void DisplayChoices()
    {

        List <Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choicesText.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of Choices given: " + currentChoices.Count);

        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;

        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }


    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame 
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine) {

            currentStory.ChooseChoiceIndex(choiceIndex);

            //InputManager.GetInstance().RegisterSubmitPressed();
        }
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

}