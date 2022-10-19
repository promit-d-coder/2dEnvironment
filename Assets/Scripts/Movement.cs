using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    jump
}

public enum LastDirection
{
    right,
    left
}

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
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator.SetFloat("lastDirection", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        //vector.y = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("horizontal", vector.x);
        playerAnimator.SetFloat("vertical", player2D.velocity.y);
        playerAnimator.SetFloat("speed", vector.sqrMagnitude);
        if(vector.x > 0f)
        {
            playerAnimator.SetFloat("lastDirection", 1f);
        }
        else if(vector.x < 0f)
        {
            playerAnimator.SetFloat("lastDirection", -1f);
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player2D.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        player2D.transform.position = player2D.position + vector * walkSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            playerAnimator.SetBool("isGrounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
            playerAnimator.SetBool("isGrounded", false);
        }
    }

}
