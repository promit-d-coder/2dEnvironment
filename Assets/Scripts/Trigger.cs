using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Animator triggerAnimator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            triggerAnimator.SetBool("isPressed", true);
            //Debug.Log("isPressed: " + true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            triggerAnimator.SetBool("isPressed", false);
            //Debug.Log("isPressed: " + false);
        }
    }
}
