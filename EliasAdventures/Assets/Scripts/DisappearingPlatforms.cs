using UnityEngine;
using DG.Tweening; // DOTween kütüphanesi

public class DisappearingPlatforms : MonoBehaviour
{
    public float disappearDuration = 1f; 
    public float delayBeforeDisappear = 2f; 
    public float reappearDelay = 3f; // Tekrar görünmeden önceki süre

    private Renderer platformRenderer;
    private Collider2D platformCollider;

    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider2D>();

        if (platformRenderer == null || platformCollider == null)
        {
            Debug.LogError("bisieksik");
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

    private void TriggerDisappear()
    {
        platformRenderer.material.DOFade(0, disappearDuration).OnComplete(() =>
        {
            platformCollider.enabled = false;

            Invoke(nameof(Reappear), reappearDelay);
        });
    }

    private void Reappear()
    {
        // Platformun tekrar görünür olması
        platformRenderer.material.DOFade(1, disappearDuration).OnComplete(() =>
        {
            platformCollider.enabled = true;
        });
    }
}
