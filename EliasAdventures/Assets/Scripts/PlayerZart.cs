using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZart : MonoBehaviour
{
    public PlayerSave data;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        SetPosAndRot();
    }
    void GetPosAndRot()
    {
        playerTransform = data.SaveTransform;
    }

    void SetPosAndRot()
    {
        data.SaveTransform = playerTransform;
    }

    private void OnApplicationQuit() {
        SetPosAndRot();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
