using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShakeObject : MonoBehaviour
{
    private void Start()
    {
        transform.DOShakePosition(1f, 0.1f, 10, 90f, false, true).SetLoops(-1, LoopType.Incremental);;
    }
}
