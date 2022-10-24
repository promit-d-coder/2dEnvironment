using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player" && !playerAnimator.GetBool("isPushing"))
        {
            playerAnimator.SetBool("isGrounded", true);
            Debug.Log("isGrounded: " + true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.name == "Player" && !playerAnimator.GetBool("isPushing") && playerAnimator.GetBool("isJumping"))
        {
            playerAnimator.SetBool("isGrounded", false);
            Debug.Log("isGrounded: " + false);
        }
    }
}
