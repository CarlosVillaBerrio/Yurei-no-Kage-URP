using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Camera focusCam;
    TutorialHandler text;

    private void Awake()
    {
        text = GetComponent<TutorialHandler>();
    }
    void Start()
    {
        text.ActivateText();
        StartCoroutine(ChangeCamera());
    }

    IEnumerator ChangeCamera()
    {
        focusCam.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        focusCam.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        focusCam.gameObject.SetActive(false);
    }
}
