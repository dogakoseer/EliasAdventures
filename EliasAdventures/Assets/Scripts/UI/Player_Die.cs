using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class Player_Die : MonoBehaviour
{
    public Animator screenAnimation;
    public int DieDuration;
    bool died;

    private void Start()
    {
        EvntManager.StartListening("Player_Die", Die);
        died = false;
    }
    private void Die()
    {
        if (died == false)
        {
            screenAnimation.SetTrigger("Die");
            died = true;
        }
        //screenanimation already include restartsane trigger in animation event do not call again
    }
    public void Restart()
    {
        EvntManager.TriggerEvent("RestartSame");
    }
}
