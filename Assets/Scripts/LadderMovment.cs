using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovment : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializedField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
           isClimbing = true;
        }

    }    
    
    private void FixUpdate()
    {
        if (isClimbing)
        {
          rb.gravityScale = 0f;
          rb.velocity = new Vector2(rb.velocity,x, verical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Ladder"))
       {
          isLadder = true;
       }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
      if (collision.CompareTag("Ladder"))
      {
         isLadder = false;
         isClimbing = false;
      }  
    }    





}
