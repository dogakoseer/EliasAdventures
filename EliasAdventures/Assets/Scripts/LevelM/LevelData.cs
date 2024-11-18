using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "SG/Level Data")]
public class LevelData:ScriptableObject
{
    public string levelName;
    public int levelNumber;
    public bool isComplated;
    public bool isUnlocked;

}