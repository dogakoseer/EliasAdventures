using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Levels : MonoBehaviour
{
    [SerializeField] private List<Level_Button_Controller> _buttons;
    [SerializeField] private List<LevelData> levels; 

    private void Start()
    {
        levels.Clear();
        foreach (var button in _buttons)
        {
            levels.Add(button.data);
        }
        Debug.Log("levels count: " + levels.Count);

        if (CheckAllLevelsForBoss())
        {
            Debug.Log("boss unlocked");
        }
        else
        {
            Debug.Log("boss locked");
        }
    }

    
    private bool CheckAllLevelsForBoss()
    {
        foreach (var level in levels)
        {
            if (!level.isComplated)
            {
                return false;
            }
        }
        return true;
    }
    /*
    private bool CheckAllLevelsForBoss()
    {
        return levels.All(level => level.isComplated);
    }
    */
}
