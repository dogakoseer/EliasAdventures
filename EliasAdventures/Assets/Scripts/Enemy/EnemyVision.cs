using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyVision : MonoBehaviour
{
    public Transform visionPoint;
    public bool NPCactive;
    public bool CanSee;

    public GameObject duz;
    public GameObject yan;
    public ParticleSystem particle;
    private void Start()
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
            Look();

            yield return new WaitForSeconds(Random.Range(1, 4));
            CanSee = false;
            DontLook();

        }
    }


    public void Look()
    {
        duz.SetActive(true);
        yan.SetActive(false);
        particle.Play();
    }
    public void DontLook()
    {
        duz.SetActive(false);
        yan.SetActive(true);
        particle.Play();
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
