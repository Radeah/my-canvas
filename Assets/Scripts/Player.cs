using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //JUMP AND MOVMENT 
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    private float coyoteTime = 0.2f; //stop double jump
    private float coyoteTimeCounter;

    //WALL SLIDING 
    private bool isWallSliding;
    private float wallSlidingSpped = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundChecker;
    [SerializeField] private LayerMask GroundLayer;

    //WALL SLIDING
    [SerializeField] private Transform WallChecker;
    [SerializeField] private LayerMask WallLayer;




    void Start()
    {

    }

    // MOVMENT SCRIP
    void Update()
    {
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
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
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
        return Physics2D.OverlapCircle(GroundChecker.position, 0.2f, GroundLayer); //jump
    }
        
    private bool isWalled() //wall
    {
        return Physics2D.OverlapCircle(WallChecker.position, 0.2f, WallLayer);
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
       private void WallJump()
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
      if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
      {
          isFacingRight = !isFacingRight;
          Vector3 localScale = transform.localScale;
          localScale.x *= -1f;
          transform.localScale = localScale;
      }
        

      



    }










}   
   