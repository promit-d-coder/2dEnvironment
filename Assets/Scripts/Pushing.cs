using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerAnimator.SetBool("isGrounded", true);
            playerAnimator.SetBool("isPushing", true);
            //Debug.Log("isPushing: " + true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerAnimator.SetBool("isGrounded", true);
            playerAnimator.SetBool("isPushing", false);
            //Debug.Log("isPushing: " + false);
        }
    }
}
