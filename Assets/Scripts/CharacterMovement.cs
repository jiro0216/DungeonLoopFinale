using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;
using TMPro;





public class CharacterMovement : MonoBehaviour
{

    //Variable for our speed modifier
    public float moveSpeed;
    //Variable for our player input
    public Vector2 movementInput;
    //Variable for our RigidBody2D
    public Rigidbody2D rigidBody;
    //Variable  for Animator
    public Animator anim;

    public int coinCounter;
    public int healthPoints;
    public TextMeshProUGUI coinCounterText,healthPointsCounter;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            // If dialogue is playing, don't update movement
            return;
        }


        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
        coinCounterText.text = coinCounter.ToString();
        healthPointsCounter.text = healthPoints.ToString();
    }

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        {
            return;

        }

        rigidBody.velocity = movementInput * moveSpeed;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            coinCounter++;
        }
        
    }
    

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();


    }

}
