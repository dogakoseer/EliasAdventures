using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Tutorial : MonoBehaviour
{
    void FixedUpdate()
    {
        Collider2D tutos = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Tutorial"));
        if (tutos != null)
            tutos.GetComponent<Controller_Tutorial>().TutoCheck();
    }

}
