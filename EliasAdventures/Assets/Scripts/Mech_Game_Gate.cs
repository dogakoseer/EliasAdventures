using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Game_Gate : Mech_Game
{
   
    public Animator animator;

    public override void Apply()
    {
        base.Apply();
        animator.SetTrigger("Open");
    }

    public override void Applied()
    {
        base.Applied();
    }
}