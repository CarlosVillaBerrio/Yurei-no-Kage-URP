using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Invector.vCharacterController;

public class TutorialHandler : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private float firstTextDuration = 0f;
    public float textDuration = 7f;
    private bool isActiveText = false;
    public GameObject panel;
    public GameObject player;
    //public GameObject camSister;
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveText)
        {

            firstTextDuration -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) || firstTextDuration < 0f)
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
                firstTextDuration = textDuration;
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            panel.gameObject.SetActive(false);
            gameObject.SetActive(false);
            vThirdPersonInput.canMove = true;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            //player.GetComponent<Rigidbody>().isKinematic = false;
            //camSister.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vThirdPersonInput.canMove = false;
            panel.gameObject.SetActive(true);
            isActiveText = true;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            //player.GetComponent<Rigidbody>().isKinematic = true;
            //camSister.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vThirdPersonInput.canMove = false;
            panel.gameObject.SetActive(true);
            isActiveText = true;
            //player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            //camSister.gameObject.SetActive(true);
        }
    }

    public void ActivateText()
    {
        panel.gameObject.SetActive(true);
        vThirdPersonInput.canMove = false;
        isActiveText = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        //player.GetComponent<Rigidbody>().isKinematic = true;
        //camSister.gameObject.SetActive(true);
    }
}
