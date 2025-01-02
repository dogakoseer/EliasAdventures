using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatforms : MonoBehaviour
{
    // Start is called before the first frame update
    public float disappearDuration = 2f; 
    public float delayBeforeDisappear = 5f; 
    public float reappearDelay = 3f; //gözükme süresi

    private Renderer platformRenderer;
    private Collider2D platformCollider;
    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider2D>();

        if (platformRenderer == null || platformCollider == null)
        {
            enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(TriggerDisappear), delayBeforeDisappear);
        }
    }
    public void TriggerDisappear()
    {

        platformRenderer.material.DOFade(0, disappearDuration).OnComplete(() =>
        {
            platformCollider.enabled = false;
            Invoke(nameof(Reappear), reappearDelay);
        });
    }

    void Reappear()
    {

        platformRenderer.material.DOFade(1, disappearDuration).OnComplete(() =>
        {
            platformCollider.enabled = true; 
        });
    }

    void Update()
    {
        
    }
}
