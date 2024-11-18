using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Panel_Open : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public RectTransform openPos;
    public RectTransform closePos;
    public float animationTime = 1f;
    PanelState state;

    public void Start()
    {
        panelRectTransform.DOAnchorPos(closePos.anchoredPosition, 0, true);
        state = PanelState.close;
    }

    public void OpenPanel()
    {
        if (state == PanelState.close)
            panelRectTransform.DOAnchorPos(openPos.anchoredPosition, animationTime, true);
        else    
        Debug.Log("Already opened!");
    }
    public void ClosePanel()
    {
        if (state == PanelState.close)
            panelRectTransform.DOAnchorPos(closePos.anchoredPosition, animationTime, true);
        else
            Debug.Log("Already closed!");
    }
}
public enum PanelState
{
    open,
    close
}