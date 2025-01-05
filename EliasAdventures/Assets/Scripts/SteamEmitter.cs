using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamEmitter : MonoBehaviour
{
    public ParticleSystem steamFX;
    public float emitDuration = 2f; //püskürtme süresi
    public float delayBeforeStart = 0f; //önceki bekleme süresi
    public float delayBetweenEmit = 3f; //püskürtmeden sonraki bekleme süresi
    public BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        StartEmitSequence();
    }
    void StartEmitSequence()
    {
        Sequence steamSequence = DOTween.Sequence();

        steamSequence.AppendInterval(delayBeforeStart);
        steamSequence.AppendCallback(() => ActivateSteam(true));
        
        steamSequence.AppendInterval(emitDuration);
        steamSequence.AppendCallback(() => ActivateSteam(false));
       
        steamSequence.AppendInterval(delayBetweenEmit);

        steamSequence.SetLoops(-1, LoopType.Restart);
    }

    void ActivateSteam(bool isActive)
    {
        if (isActive)
        {
            steamFX.Play();
            collider.enabled = true;
            
        }
        else
        {
            steamFX.Stop();
            collider.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
