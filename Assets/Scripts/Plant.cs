using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameManager gameManager;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D actor)
    {
        if (actor.CompareTag("Player"))
        {
            animator.SetBool("IsPlayerInRange", true);
            Debug.Log("Eat");
        }
    }

    private void OnTriggerExit2D(Collider2D actor)
    {
        if (actor.CompareTag("Player"))
        {
            animator.SetBool("IsPlayerInRange", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetBool("IsPlayerInRange", false);
            gameManager.isPlayerDead = true;
            Debug.Log("Dead");
        }

        if (collision.gameObject.name == "Rock")
        {
            animator.SetBool("IsPlayerInRange", false);
            Destroy(this.gameObject);   
            Debug.Log("Plant Dead");
        }
    }
}
