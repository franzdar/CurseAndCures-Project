using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D actor)
    {
        if (actor.CompareTag("Player"))
        {
            playerMovement.isClimbing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D actor)
    {
        if (actor.CompareTag("Player"))
        {
            playerMovement.isClimbing = false;
        }
    }
}
