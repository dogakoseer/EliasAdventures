using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "LevelData", menuName = "SG/Level Data")]
public class LevelData:ScriptableObject
{
    public Sprite sprite;
    public string levelName;
    public int levelNumber;
    public bool isComplated;
    public bool isUnlocked;

}