using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public bool blink = false;
    public float timeDelay;


    void Update()
    {
        if (blink == false)
        {
            StartCoroutine(AutoToggleLight());
        }
    }
    IEnumerator AutoToggleLight()
    {
        blink = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.02f, 0.6f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.02f, 0.6f);
        yield return new WaitForSeconds(timeDelay);
        blink = false;


    }
}
