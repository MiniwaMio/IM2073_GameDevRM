using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBounceScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI speech;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        speech.gameObject.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        speech.gameObject.SetActive(false);
    }
}
