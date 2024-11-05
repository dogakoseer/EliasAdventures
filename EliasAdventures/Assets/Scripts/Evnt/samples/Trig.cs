using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    
    private void Start() {
        Invoke("aaaa", 1f);
    }
    void aaaa()
    {
        EvntManager.TriggerEvent("test");
        EvntManager.TriggerEvent("a");
    }

}
