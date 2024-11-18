using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButtonController : MonoBehaviour
{
    public MusicController musicController;
    public TMPro.TMP_Text musicStateText;
    // Start is called before the first frame update
    void Start()
    {
        musicController = FindObjectOfType<MusicController>() as MusicController;
        WriteSituation();
    }
    public void Play()
    {
        musicController.Music();
        WriteSituation();
    }
    private void WriteSituation()
    {
        switch (musicController.isPlaying())
        {
            case true:
                musicStateText.text = "Music= on";
                break;
            case false:
                musicStateText.text = "Music= off";
                break;
        }
    }
}
