using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        Move();

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
        isGrounded = false;
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            transform.DOScale(new Vector3(originalScale.x * crouchScale.x, originalScale.y * crouchScale.y, 1f), 0.2f); // DOTween ile yumuşak eğilme
        }
    }

    void StandUp()
    {
        if (isCrouching)
        {
            isCrouching = false;
            transform.DOScale(originalScale, 0.2f); // DOTween ile eski boyuta geri dönme
        }
    }
    void AnimationUp()
    {
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }


}
