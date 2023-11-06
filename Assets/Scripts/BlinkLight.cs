using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public bool blink = false;
    public float timeDelay;
    public float minRange = 0.02f;
    public float maxRange = 0.6f;



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
        timeDelay = Random.Range(minRange, maxRange);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(minRange, maxRange);
        yield return new WaitForSeconds(timeDelay);
        blink = false;


    }
}
