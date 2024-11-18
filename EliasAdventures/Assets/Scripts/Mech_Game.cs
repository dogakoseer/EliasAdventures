using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Game : MonoBehaviour
{
    public GameObject MechPanel;
    private void Start() {
        MechPanel.SetActive(false);

    }
    public void Show()
    {
        if (MechPanel != null)
        {
            MechPanel.SetActive(true);
        }

    }
}
