using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level_Button_Controller : MonoBehaviour
{
    [SerializeField]public LevelData data;
    
    public TMP_Text title;
    public Button button;
    // complated gelecek
    private void Start()
    {   
        if(data == null) Debug.LogWarning(this.name + " is missing data");
        Write();
    }
    void Write()
    {
        title.text = data.levelName;
        button.interactable = data.isUnlocked;
    }
}
