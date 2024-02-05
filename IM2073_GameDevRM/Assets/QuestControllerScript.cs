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
    public GameObject can2;

    

    private int counter = 0;
    // Start is called before the first frame update

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Triggered1");
        speech.gameObject.SetActive(true);
        speech.text = "Press E to take food";
        if(Input.GetKeyDown(KeyCode.E) && collision.collider.gameObject.name == "Can_1")
        {
            counter++;
            quest.text = "Find food " + counter + "/2";
            
            can1.SetActive(false);
                
        }

        
        if (Input.GetKeyDown(KeyCode.E) && collision.collider.gameObject.name == "Can_3")
        {
            counter++;
            quest.text = "Find food " + counter + "/2";
            can2.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
    }

    private void OnCollisionExit(Collision collision)
    {
        speech.gameObject.SetActive(false);
    }
    void Start()
    {
        can1 = GameObject.Find("Can_1");

        can2 = GameObject.Find("Can_3");
        Debug.Log("Triggered1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
