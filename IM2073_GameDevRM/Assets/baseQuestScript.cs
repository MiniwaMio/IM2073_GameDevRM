using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class baseQuestScript : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI quest;
    [SerializeField]
    TextMeshProUGUI speech;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            speech.text = "Press e to get in";
            speech.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        speech.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
