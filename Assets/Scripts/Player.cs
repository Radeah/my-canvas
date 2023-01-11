using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private float speed = 200f;
    private float jumpingPower = 5f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundChecker;
    [SerializeField] private LayerMask GroundLayer;



    void Start()
    {

    }

    // MOVMENT SCRIP
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //move

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundChecker.position, 0.2f, GroundLayer);
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
   