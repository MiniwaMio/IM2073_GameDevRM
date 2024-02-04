using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;




public class DialogueManager : MonoBehaviour

{
  [SerializeField] private GameObject dialogueParent;
  [SerializeField] private TMP_Text dialogueText;
  [SerializeField] private Button option1Button;

  [SerializeField] private float typingSpeed = 0.05f;
  [SerializeField] private float turnSpeed = 2f;

  private List<dialogueString> dialogueList;

  [Header("Player")]
  [SerializeField] private PlayerFPS FirstPersonController;
  private Transform playerCamera;

  private int cuurentDialogueIndex = 0;

  private void Start()
  {
    dialogueParent.SetActive(false);
    playerCamera = Camera.main.transform;
  }

    public void dialogueSatrt(List<dialogueString> texttoPrint, Transform NPC)
    {
        dialogueParent.SetActive(true);
        FirstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(TurnCameraTowardsNPC(NPC));

        dialogueList = textToPrint;
        currentDialogueIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialogue());
    }

    private void DisableButtons()
    {
        option1Button.interactable = false; 

        option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
    }

    private IEnumerator TurnCameraTowardsNPC(Transform NPC)
    {
        Quaternion startRotation = playerCamera.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(NPC.position - playerCamera.position);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime + turnSpeed;
            yield return null;

        }

        playerCamera.rotation = targetRotation;
    }

    private bool optionSelected = false;

    private IEnumerator PrintDialogie()
    {
        while (currentDialogueIndex < dialogueList.Count)
        {
            dialogueString line = dialogueList[currentDialogueIndex];

            line.startDialogueEvent? .Invoke();

            if (line.isQuestion)
            {
                yield return StartCoroutine(TypeText(line.text));
                
                option1Button.interactable = true; 

                 option1Button.GetComponetInChildren<TMP_Text>().text = line.answwerOption1;

                 option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1IndexJump));

                 yield return new WaitUntil(() => optionSelected);
            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));
            }

            line.endDialogueEvent? .Invoke();

            optionSelected = false;
            
        }

        DialogueStop();
    }

    private void HandleOptionSelected(int indexJump)
    {
        optionSelected = true;
        DisableButtons();

        currentDialogueIndex = indexJump;
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if(!dialogueList[currentDialogueIndex].isQuestion)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        if(dialogueList[currentDialogueIndex].isEnd)
            DialogueStop();

        currentDialogueIndex++;
    }

    private void DialogueStop()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        dialogueParent.SetActive(false);

        FirstPersonController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 }
