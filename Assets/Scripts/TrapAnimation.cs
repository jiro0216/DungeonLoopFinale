using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimation : MonoBehaviour
{
    public Animator anim;
    public CharacterMovement player;
    public int trapDamage;
    public bool playerOnTop;
    // Start is called before the first frame update
    void Start()
    {
        playerOnTop = false;         
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.CompareTag("Player"))
        {
            playerOnTop = true;
            anim.SetBool("isActive", true);
            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnTop = false;
            anim.SetBool("isActive",false);

        }
    }

    public void PlayerDamage()
    {
        if (playerOnTop)
        {

            player.healthPoints -= trapDamage;
        } 
       
    }
}
