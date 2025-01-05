using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{

    public GameObject answerUI;
    public GameObject door;
    public BoxCollider2D collider;
    private bool isUnlocked = false;

    private void Start()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isUnlocked)
        {
            answerUI.SetActive(true);
            collider.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            answerUI.SetActive(false);
            collider.enabled = false;
        }
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            isUnlocked = true;
            collider.enabled = false;
            door.SetActive(false);
            answerUI.SetActive(false);
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
