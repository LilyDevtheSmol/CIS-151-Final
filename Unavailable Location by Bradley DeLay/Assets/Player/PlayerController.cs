using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("COMPONENTS")]
    private Animator animator;
    private Rigidbody2D body;
    public GameObject flashlight;

    [Header("PLAYER MOVEMENT")]
    private float moveY;
    private float moveX;
    private float runSpeed = 4f;

    [Header("ANIMATIONS")]
    private string currentState;
    const string IDLE = "Idle";
    const string RUN = "Walk_Cycle";

    void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // track player x movement 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // move right (positive direction along x-axis)  
            moveX = 1;
            ChangeAnimationState(RUN);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // move left (negative direction along x-axis)
            moveX = -1;
            ChangeAnimationState(RUN);
        }
        else
        {
            // no movement along x-axis 
            moveX = 0;
            if (moveY == 0) { ChangeAnimationState(IDLE); }
        }

        // track player y movement 
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.RightArrow))
        {
            // move up (positive direction along x-axis)  
            moveY = 1;
            ChangeAnimationState(RUN);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftArrow))
        {
            // move down (negative direction along x-axis)
            moveY = -1;
            ChangeAnimationState(RUN);
        }
        else
        {
            // no movement along y-axis 
            moveY = 0;
            if (moveX == 0) { ChangeAnimationState(IDLE); }
        }

        FlashlightRotation();
    }

    void FixedUpdate()
    {
        // process player movement 
        body.velocity = new Vector2((moveX * runSpeed), body.velocity.y);
        body.velocity = new Vector2(body.velocity.x, (moveY * runSpeed));
        // 0f for y breaks me....

    }

    void FlashlightRotation() 
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - flashlight.transform.position.x,
                                        mousePosition.y - flashlight.transform.position.y);
        flashlight.transform.up = direction;
    }

    void ChangeAnimationState(string newState)
    {
        // update the players animation state 
        if (currentState == newState)
        {
            return;
        }

        // Play the animation
        animator.Play(newState);

        // Reassign the current state
        currentState = newState;
    }
}
