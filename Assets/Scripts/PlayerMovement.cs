using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    public bool isGrounded;
    public bool isClimbing;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        // Climbing Mechanic
        if (!isClimbing)
        {
            rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
            rb.gravityScale = 3;
        }
        else
        {
            rb.velocity = new Vector2(dirX * movementSpeed, dirY * movementSpeed);
            rb.gravityScale = 0;
        }

        // Grounded Mechanic
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }


        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
