using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCont : MonoBehaviour
{
    public GameObject UI_Tutorial;
    public bool learned = false;

    public void TutoCheck()
    {
        if (!learned)
        {
            learned = true;
            UI_Tutorial.SetActive(true);
        }
    }
    
}
