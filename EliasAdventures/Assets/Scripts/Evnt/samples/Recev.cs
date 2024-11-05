using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recev : MonoBehaviour
{
       void Start()
    {
        EvntManager.StartListening("test", () => Debug.Log("test"));    
        EvntManager.StartListening("a",allah);
    }

    private void allah()
    {
        Debug.Log("allah has been triggered");
    }
}
