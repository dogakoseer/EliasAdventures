using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : MonoBehaviour
{
    public float rotationDuration = 2f; 
    public bool clockwise = true;
    
    // Start is called before the first frame update
    void Start()
    {
        RotateWheel();
    }
    void RotateWheel()
    {
        float rotationAngle;
        if (clockwise)
        {
            rotationAngle = 360f; 
        }
        else
        {
            rotationAngle = -360f; 
        }

        transform.DORotate(new Vector3(0, 0, rotationAngle), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear) 
            .SetLoops(-1, LoopType.Yoyo); 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
