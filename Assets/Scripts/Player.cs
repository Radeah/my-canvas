using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //JUMP AND MOVMENT 
    private float horizontal;
    private float speed = 450f;
    private float jumpingPower = 100f;
    private bool isFacingRight = true;

    private float coyoteTime = 0.2f; //stop double jump
    private float coyoteTimeCounter;

    //WALL SLIDING 
    private bool isWallSliding;
    private float wallSlidingSpped = 90f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.2f;
    private Vector2 wallJumpingPower = new Vector2(200f, 200f);

    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundChecker;
    [SerializeField] private LayerMask GroundLayer;

    //WALL SLIDING
    [SerializeField] private Transform WallChecker;
    [SerializeField] private LayerMask WallLayer;

    //stop infinite jump
    private float jumpBufferingTime = 0.2f;
    private float jumpBufferingCounter;
    DialogueManager dm;



    void Start()
    {
        jumpBufferingCounter = -0.1f;
        dm = FindObjectOfType<DialogueManager>();

    }

    // MOVMENT SCRIP
    void Update()
    {
        if (dm.coversation == false) 
        {
            if (jumpBufferingCounter > 0)
            {
                jumpBufferingCounter = jumpBufferingCounter - Time.deltaTime;
            }

            horizontal = Input.GetAxisRaw("Horizontal"); //move
            if (IsGrounded())
            {
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {

                if (jumpBufferingCounter < 0f) //jump
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                    jumpBufferingCounter = jumpBufferingTime;
                }
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //jump
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.2f);

                coyoteTimeCounter = 0f;
            }

            //wall jumping
            WallSlide();
            WallJump();

            if (!isWallJumping)
            {
                Flip();
            }
        }

        
    }

    private void FixedUpdate()
    {   if (!isWallJumping)
        {
          rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        
    }

    private bool IsGrounded() //jump
    {
        return Physics2D.OverlapCircle(GroundChecker.position, 0.01f, GroundLayer); //jump
    }
        
    private bool isWalled() //wall
    {
        return Physics2D.OverlapCircle(WallChecker.position, 0.01f, WallLayer);
    }

    private void WallSlide() //wall
    {
       if (isWalled() && !IsGrounded() && horizontal != 0f)
       {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpped, float.MaxValue));
       }
       else
       {
            isWallSliding = false;
       }
    }
       private void WallJump() //wall 
       {
         if (isWallSliding)
         {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping)); 
         }
         else
         {
            wallJumpingCounter -= Time.deltaTime;
         }
         if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
         {
            isWallJumping = true; 
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);

         }    

       }
       
    private void StopWallJumping()
    {
        isWallJumping = false;

    }

    private void Flip()
    {
      if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) //walking
      {
          isFacingRight = !isFacingRight;
          Vector3 localScale = transform.localScale;
          localScale.x *= -1f;
          transform.localScale = localScale;
      }
        

      



    }










}   
   