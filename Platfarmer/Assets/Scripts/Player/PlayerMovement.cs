using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public static float moveSpeed =7f;
    public static float jumpingPower = 15f;
    public static float slamPower = -30f;
    private bool facingRight = true;
    private bool canDash = true;
    private bool dashing;
    private float dashingPower = 28f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 3f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    //changes which way player faces
    private void Flip()
    {
        if(facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    //checks if on the ground
    private bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //dash
    public IEnumerator Dash()
    {
        canDash = false;
        dashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        dashing = false;
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    //movement
    public void Move()
    {
        if(dashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    //jump
    public void Jump()
    {
        if(dashing)
        {
            return;
        }
        if(Input.GetButtonDown("Jump") && Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    //dash activation
    public void DashInput()
    {
        if(dashing)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public void Slam()
    {
        if(dashing)
        {
            return;
        }
        if(!Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, slamPower);
        }
    }
}
