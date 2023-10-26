using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalismanRecharger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Recharger found");
            other.gameObject.GetComponentInChildren<TalismaBehavior>().IsOnRecharger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Recharger out");
            other.gameObject.GetComponentInChildren<TalismaBehavior>().IsOutOfRecharger();
        }
    }
}
