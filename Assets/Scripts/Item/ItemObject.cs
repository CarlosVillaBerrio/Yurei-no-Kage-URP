using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    public GameObject objectToActivate;
    public TextMeshProUGUI text;
    public GameObject iconImg;
    bool canPick = true;


    private void Start()
    {
        iconImg = Instantiate(iconImg, this.transform.position, Quaternion.identity);
        iconImg.transform.SetParent(GameObject.Find("Canvas").transform);
    }
    private void OnValidate()
    {
        gameObject.name = "Item - " + itemData.ItemName;
    }

    private void Update()
    {
        if (iconImg)
        {
            iconImg.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Face")
        {
            iconImg.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Face")
        {
            iconImg.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Face" && Input.GetKey(KeyCode.E) && canPick)
        {
            canPick = false;
            int random = Random.Range(1, 3);

            switch (random)
            {
                case 1:
                    text.text = "An evidence, yay!";
                    break;
                case 2:
                    text.text = "I found it";
                    break;
                case 3:
                    text.text = "Gotcha";
                    break;
            }

            StartCoroutine(TextTrigger());
            Inventory.instance.AddItem(itemData);
            if (objectToActivate != null)
                objectToActivate.SetActive(true);
            Destroy(iconImg.gameObject, 1f);
            Destroy(gameObject, 1f);
        }

        if(other.gameObject.tag == "Face")
        {
            iconImg.gameObject.SetActive(true);
        }
    }

    IEnumerator TextTrigger()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        text.gameObject.SetActive(false);

    }
}
