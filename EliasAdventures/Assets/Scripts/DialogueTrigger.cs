using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueManager; // DialogueManager Prefab
    public GameObject canvas;


    private bool isDialogueActive = false; // Diyalog açýk mý kontrolü
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Entered by Player");
            dialogueManager.SetActive(true);
            canvas.SetActive(true); // Diyalog sistemini aktif et
            // Diyalog sistemini aktif et
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Test");
            canvas.SetActive(false);

            dialogueManager.SetActive(false); // Diyalog sistemini devre dýþý býrak
            isDialogueActive = false; // Diyalog pasif olarak ayarla
        }
    }
}
