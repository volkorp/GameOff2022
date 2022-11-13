using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 15;
    [SerializeField] float jumSpeed = 5;
    Rigidbody2D rigidbodyPlayer;
    Collider2D colliderPlayer;
    SpriteRenderer spriteRendererPlayer;
    Animator animatorPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPlayer = gameObject.GetComponent<Rigidbody2D>();
        colliderPlayer = gameObject.GetComponent<Collider2D>();
        spriteRendererPlayer = gameObject.GetComponent<SpriteRenderer>();
        animatorPlayer = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
        checkForGround();
    }

    private void Run()
    {
        var getDirection = Input.GetAxis("Horizontal");
        rigidbodyPlayer.velocity = new Vector2(getDirection * runSpeed, rigidbodyPlayer.velocity.y);
        animatorPlayer.SetBool("isRunning", true);

        if (getDirection == 0)
        {
            animatorPlayer.SetBool("isRunning", false);
        }

    }
    private void Jump()
    {
        animatorPlayer.SetFloat("jumpVelocity", rigidbodyPlayer.velocity.y);
        if (!colliderPlayer.IsTouchingLayers(LayerMask.GetMask("floor"))) { return; }
        if (Input.GetButton("Jump") || Input.GetKey("up"))
        {
            rigidbodyPlayer.velocity = new Vector2(rigidbodyPlayer.velocity.x, jumSpeed);

        }
    }

    private void FlipSprite()
    {
        if (rigidbodyPlayer.velocity.x < 0)
        {
            spriteRendererPlayer.flipX = true;
        }
        else if (rigidbodyPlayer.velocity.x > 0)
        {
            spriteRendererPlayer.flipX = false;
        }
    }

    private void checkForGround()
    {

        if (colliderPlayer.IsTouchingLayers(LayerMask.GetMask("floor")))
        {
            animatorPlayer.SetBool("isGrounded", true);
        }
        else
        {
            animatorPlayer.SetBool("isGrounded", false);
        }

    }
}
