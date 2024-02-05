using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestControllerScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI quest;
    [SerializeField]
    TextMeshProUGUI speech;
    [SerializeField]
    public GameObject can1;

    [SerializeField]
    public GameObject baseQuest;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            speech.text = "Press e to take food";
            speech.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject.tag == "food1")
                {
                    can1.SetActive(false);
                    quest.text = "Objective: Return to base";
                    speech.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    baseQuest.SetActive(true);

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        speech.gameObject.SetActive(false);
    }
    void Start()
    {
        can1 = GameObject.Find("Can_1");
        baseQuest = GameObject.FindWithTag("baseq");
        baseQuest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
