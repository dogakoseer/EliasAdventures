using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Olta : MonoBehaviour
{
    public Slider slider;
    public float targetStart = 0.85f;
    public float targetEnd = 1f;
    public float speed = 1f;
    public GameObject panel;

    private bool isFishing = false;
    public bool isDone = false;
    private Tween sliderTween;

    void Start()
    {
        panel.SetActive(false);
        isDone = false;
    }

    public void FixedUpdate()
    {
        Collider2D cols = Physics2D.OverlapCircle(transform.position, 1.5f, LayerMask.GetMask("Player"));

        if (cols != null && !isFishing && !isDone)
        {
            panel.SetActive(true);
            StartFishing();

        }

    }

    public void StartFishing()
    {
        isFishing = true;

        slider.value = 0;

        // Slider değerini 0 ile 1 arasında ileri geri hareket ettir
        sliderTween = DOTween.To(() => slider.value, x => slider.value = x, 1f, speed)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .OnStepComplete(() =>
            {

            });
    }

    public void StopFishing()
    {
        if (!isFishing) return;


        isFishing = false;  
        sliderTween.Kill();


        if (slider.value >= targetStart && slider.value <= targetEnd)
        {

            Debug.Log("KAZANDIN!");
            isFishing = false;
            isDone = true;
            panel.SetActive(false);
            sliderTween.Kill();

            //win condition
        }
        else
        {
            Debug.Log("KAÇIRDIN!");
            isFishing = false;
            sliderTween.Kill();
        }


    }
}
