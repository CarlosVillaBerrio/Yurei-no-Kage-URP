using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    public GameObject text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }   
}
