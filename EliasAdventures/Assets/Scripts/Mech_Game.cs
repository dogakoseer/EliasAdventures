using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mech_Game : MonoBehaviour
{
    public bool canInteractable;
    public bool interacted;
    public GameObject MechPanel;
    public Button InteractionButton;
    
    public virtual void Start()
    {
        MechPanel.SetActive(false);
        canInteractable = false;
        interacted = false;
    }
    public virtual void Show()
    {
        if (MechPanel != null && !interacted)
        {
            MechPanel.SetActive(true);
            canInteractable = true;
            InteractionButton.onClick.AddListener(Apply);
            InteractionButton.gameObject.SetActive(true);
        }
    }
    

    public virtual void Apply()
    {
        Applied();
    }
    public virtual void Applied()
    {
        MechPanel.SetActive(false);
        InteractionButton.onClick.RemoveAllListeners();
        InteractionButton.gameObject.SetActive(false);
        interacted = true;
    }
}
