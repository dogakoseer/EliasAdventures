using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TutorialData", menuName = "SG/Tutorial")]
public class SO_Tutorial : ScriptableObject
{
    public string tutorialTitle;
    public string tutorialDescription;
    public bool tutorialLearned;
}
