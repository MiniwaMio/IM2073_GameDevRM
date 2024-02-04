using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSpawningScript : MonoBehaviour
{
    public GameObject spawning;

    public bool isSpawning = false;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (isSpawning == false)
        {
            spawning.SetActive(true);
            isSpawning = true;
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
