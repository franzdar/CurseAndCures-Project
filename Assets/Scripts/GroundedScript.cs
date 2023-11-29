using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedScript : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnCollisionStay2D(Collision2D actor)
    {
        if (actor.gameObject.name == "Player")
        {
            playerMovement.isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D actor)
    {
        if (actor.gameObject.name == "Player")
        {
            playerMovement.isGrounded = false;
        }
    }
}
