using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class InkDialogue : MonoBehaviour
{
    [Header("Ink JSON")]
    public TextAsset inkJSONAsset; 
    private Story story;

    [Header("UI Elements")]
    public TMP_Text dialogueText; // diyalog tmp
    public Button[] optionButtons; 
    public GameObject dialogueCanvas;
    void Start()
    {
        dialogueCanvas.SetActive(false); //trigger olmadan diyalog canvasý kapalý. npc oluþturulup box collider eklenecek
        if (inkJSONAsset != null)
        {
            story = new Story(inkJSONAsset.text); // json yükle
            RefreshView();
        }
        else
        {
            Debug.LogError("json yok");
        }
    }
    public void StartDialogue()
    {
        dialogueCanvas.SetActive(true); // Canvas'ý göster
        RefreshView();
    }
    void RefreshView()
    {

        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
        }
        else
        {
            dialogueText.text = "the end";
            HideDialogue();
        }

        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }

        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMP_Text>().text = story.currentChoices[i].text; 

                int choiceIndex = i; 
                optionButtons[i].onClick.RemoveAllListeners(); 
                optionButtons[i].onClick.AddListener(() => OnChoiceSelected(choiceIndex));
            }
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        RefreshView();
    }
    public void HideDialogue()
    {
        dialogueCanvas.SetActive(false);
    }
    void Update()
    {

    }

}
