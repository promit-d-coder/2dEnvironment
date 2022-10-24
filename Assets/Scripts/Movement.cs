using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Player walking speed
    [SerializeField] private float walkSpeed;
    //Player rigid body 2D 
    [SerializeField] private Rigidbody2D player2D;
    //Player animator
    [SerializeField] private Animator playerAnimator;
    Vector2 vector;
    [SerializeField] private BoxCollider2D playerCollider;
    //private PlayerState pState;
    //private LastDirection lDirection;
    private bool isGrounded = false;
    private bool isPushing = false;
    // Start is called before the first frame update
    void Start()
    {        
        playerAnimator.SetFloat("lastDirection", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        isGrounded = playerAnimator.GetBool("isGrounded");
        isPushing = playerAnimator.GetBool("isPushing");
        if (player2D.velocity.y != 0f && !isGrounded)
        {
            playerAnimator.SetFloat("vertical", player2D.velocity.y);
            Debug.Log("Fall Velocity: " + player2D.velocity.y);
        }
        else if(player2D.velocity.y == 0f && playerAnimator.GetBool("isJumping"))
        {
            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isGrounded", true);
        }
            
        playerAnimator.SetFloat("horizontal", vector.x);
        
        playerAnimator.SetFloat("speed", vector.sqrMagnitude);
        if(vector.x > 0f)
        {
            playerAnimator.SetFloat("lastDirection", 1f);
        }
        else if(vector.x < 0f)
        {
            playerAnimator.SetFloat("lastDirection", -1f);
        }

        
        if (isGrounded && !isPushing && player2D.velocity.y == 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !playerAnimator.GetBool("isJumping"))
            {
                playerAnimator.SetBool("isJumping", true);
                player2D.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
            }
        }

        if(isGrounded && isPushing && playerAnimator.GetFloat("speed") == 0f)
        {
            player2D.AddForce(new Vector2(-5f * playerAnimator.GetFloat("lastDirection"), 0), ForceMode2D.Force);
        }
    }

    private void FixedUpdate()
    {
        player2D.transform.position = player2D.position + Time.fixedDeltaTime * walkSpeed * vector;
    }

    
}
