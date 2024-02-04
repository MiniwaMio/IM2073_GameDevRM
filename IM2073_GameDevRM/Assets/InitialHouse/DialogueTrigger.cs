using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<dialogueString> dialogueStrings = new List<dialogueString>();
    [SerializeField] private Transform NPCTransform;

    private bool hasSpoken = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !hasSpoken)
        {
            other.gameObject.GetComponent<DialogueManager>().dialogueSatrt(dialogueStrings, NPCTransform);
            hasSpoken = true;
        }
    }
}

[System.Serializable]

public class dialogueString
{
    public string text; //represent the text that the npc says
    public bool isEnd; 

    [Header("Branch")]
    public bool isQuestion;
    public string answwerOption1;
    public int option1IndexJump;

    [Header("Triggered Events")]
    public UnityEvent startDialogueEvent;
    public UnityEvent endDialogueEvent;
}