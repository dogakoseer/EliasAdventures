using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f;  // ???? hantal oldu bu
    public float jumpHeight = 2f;
    private bool isGrounded = true;
    private Tween moveTween;
    private bool isCrouching = false;
    private Vector2 startTouchPosition, endTouchPosition;
    public float swipeThreshold = 50f;


    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.deltaPosition;

                // right movement
                if (touchDelta.x > 0)
                {
                    StartMoving(Vector3.right);
                }
                // left movement 
                else if (touchDelta.x < 0)
                {
                    StartMoving(Vector3.left);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                StopMoving();
                HandleSwipe();
            }
        }
    }
    void HandleSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x)) // swipe up
        {
            if (swipeDelta.y > swipeThreshold)
            {
                if (isCrouching)
                {
                    // stand up
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    isCrouching = false;
                }
                else
                {
                    // jump
                    Jump();
                }
            }
            else if (swipeDelta.y < -swipeThreshold)
            {

                Crouch();
            }
        }
    }
    void StartMoving(Vector3 direction)
    {
        moveTween?.Kill(); // Önceki hareketi durdur.
        moveTween = transform.DOBlendableMoveBy(direction * moveSpeed, 0.5f).SetLoops(-1, LoopType.Incremental);
    }


    void StopMoving()
    {
        moveTween?.Kill();
    }
    void Crouch()
    {
        if (!isCrouching)
        {
            transform.DOScaleY(0.5f, 0.3f).SetEase(Ease.OutQuad);
            isCrouching = true;
        }
    }
    void Jump()
    {
        if (isGrounded && !isCrouching)
        {
            isGrounded = false;
            transform.DOMoveY(transform.position.y + jumpHeight, 0.5f).SetEase(Ease.OutQuad).OnComplete(() => {
                isGrounded = false; // Yere iniþten sonra sýfýrlanmazsa burada false olabilir.
            });
        }
    }

    // Zemine temas kontrolü - overlap circile
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true; 
        }
    }

}



