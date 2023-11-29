using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrap : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D actor)
    {
        if (actor.CompareTag("Player"))
        {
            gameManager.isPlayerDead = true;
            Debug.Log("Dead");
        }
    }
}
