using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform startPoint; 
    public Transform endPoint;
    public float duration = 3f;
    public Ease movementEase = Ease.InOutSine;
    public bool loop = true;

    private bool moveToEnd = true;
    // Start is called before the first frame update
    void Start()
    {
        MoveToPoint();
    }

    void MoveToPoint()
    {
        Vector3 targetPosition;
        if (moveToEnd)
        {
            targetPosition = endPoint.position; 
        }
        else
        {
            targetPosition = startPoint.position;
        }

        transform.DOMove(targetPosition, duration)
            .SetEase(movementEase)
            .OnComplete(() =>
            {
                if (loop)
                {
                    moveToEnd = !moveToEnd;
                    MoveToPoint();
                }
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
