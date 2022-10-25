using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Animator triggerAnimator;
    private BoxCollider2D platformCollider;
    private Animator platformAnimator;

    private void Start()
    {
       platformCollider = this.gameObject.GetComponent<BoxCollider2D>();
       platformAnimator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (triggerAnimator.GetBool("isPressed"))
        {
            platformAnimator.SetBool("isPlatform", false);
            platformCollider.enabled = false;
        }
        else
        {
            platformAnimator.SetBool("isPlatform", true);
            platformCollider.enabled = true;
        }
    }
}
