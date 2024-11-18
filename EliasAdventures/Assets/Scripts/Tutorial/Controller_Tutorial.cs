using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Tutorial : MonoBehaviour
{
    public GameObject UI_Tutorial;
    public bool learned = false;
    public TMPro.TMP_Text tmp_Header;
    public TMPro.TMP_Text tmp_Description;
    public SO_Tutorial data;
    //scriptable objecter gecilip tek ekrana alinacak tum tutorial bilgileri
    private void Start()
    {
        if (UI_Tutorial == null)
        {
            UI_Tutorial = GameObject.FindGameObjectWithTag("UI_Tutorial");
        }
        GetData();
        
    }
    public void GetData()
    {
        learned = data.tutorialLearned;
    }

    public void TutoCheck()
    {
        if (!learned)
        {
            learned = true;
            data.tutorialLearned = learned;
            tmp_Header.text = data.tutorialTitle;
            tmp_Description.text = data.tutorialDescription;
            UI_Tutorial.SetActive(true);
        }
    }

}
