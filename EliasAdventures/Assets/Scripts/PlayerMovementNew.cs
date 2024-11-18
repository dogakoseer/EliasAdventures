using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
public enum Rot
{
    left, right
}

public class PlayerMovementNew : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Vector2 crouchScale = new Vector2(1f, 0.5f);
    private Vector2 originalScale;
    public Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isCrouching;
    private Rot rot;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        Move();
        Rotate();
        // Zıplama
        if (joystick.Vertical > 0.5f && isGrounded && !isCrouching)
        {
            Jump();
        }

        // Eğilme
        if (joystick.Vertical < -0.5f && isGrounded)
        {
            Crouch();
        }
        else
        {
            StandUp();
        }
        AnimationUp();
    }
    private void Rotate()
    {
        if (joystick.Horizontal > 0)
        {
            rot = Rot.right;
        }
        else if (joystick.Horizontal < 0)
        {
            rot = Rot.left;
        }
        LastRotate();

    }
    private void LastRotate()
    {
        if (rot == Rot.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
            transform.rotation = Quaternion.Euler(0, -180, 0);
    }


    void Move()
    {
        float horizontalInput = joystick.Horizontal;
        float speed = isCrouching ? crouchSpeed : moveSpeed;
        Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        if (isGrounded)
        {
            isGrounded = false;
            animator.SetBool("IsJump", true);

        }
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            animator.SetBool("IsCrouch", true);
        }
    }

    void StandUp()
    {
        if (isCrouching)
        {
            isCrouching = false;
            animator.SetBool("IsCrouch", false);
        }
    }
    void AnimationUp()
    {
        animator.SetFloat("Speed", math.abs(rb.velocity.x / moveSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Mech"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
                animator.SetBool("IsJump", false);
            }

        }
    }


}
