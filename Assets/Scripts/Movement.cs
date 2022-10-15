using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    jump
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
    private PlayerState pState;
    // Start is called before the first frame update
    void Start()
    {
        pState = PlayerState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("horizontal", vector.x);
        playerAnimator.SetFloat("vertical", vector.y);
        playerAnimator.SetFloat("speed", vector.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        player2D.transform.position = player2D.position + vector * walkSpeed * Time.fixedDeltaTime;
    }
}
