using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyVision : MonoBehaviour
{
    public Transform visionPoint;
    public bool NPCactive;
    public bool CanSee;
    public Quaternion lookRot;
    public Quaternion lookFwd;

    public void Start()
    {
        StartCoroutine(See());
        NPCactive = true;
    }


    public IEnumerator See()
    {
        while (NPCactive)
        {
            yield return new WaitForSeconds(Random.Range(2, 4));
            CanSee = true;
            transform.DORotateQuaternion(lookFwd, 1);

            yield return new WaitForSeconds(Random.Range(1, 4));
            CanSee = false;
            transform.DORotateQuaternion(lookRot, 1);

        }
    }



    private void FixedUpdate()
    {
        if (CanSee)
        {
            if(Physics2D.OverlapCircle(visionPoint.position, 2f,LayerMask.GetMask("Player")) != null)
            {
                EvntManager.TriggerEvent("Player_Die");
            }
        }
    }
}
