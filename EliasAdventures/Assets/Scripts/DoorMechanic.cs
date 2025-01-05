using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{

    public GameObject answerUI;
    public GameObject door;
    public Collider2D col;
    private bool isUnlocked = false;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isUnlocked)
        {
            answerUI.SetActive(true);
            col.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            answerUI.SetActive(false);
        }
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            isUnlocked = true;
            door.SetActive(false);
            answerUI.SetActive(false);
            col.isTrigger = true;
        }
        else
        {
            EvntManager.TriggerEvent("Player_Die");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
