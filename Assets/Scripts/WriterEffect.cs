using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class WriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f; 
    public string fullText;

    private TMP_Text textComponent;
    //private 
    private string currentText = "";
    private int index = 0;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        fullText = textComponent.text; 
        textComponent.text = "";
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        while (index < fullText.Length)
        {
            currentText += fullText[index];
            textComponent.text = currentText;
            index++;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
