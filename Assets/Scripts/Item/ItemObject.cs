using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    public GameObject objectToActivate;
    public TextMeshProUGUI text;

    private void OnValidate()
    {
        gameObject.name = "Item - " + itemData.ItemName;
    }     

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
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
            Destroy(gameObject, 1f);
        }
    }

    IEnumerator TextTrigger()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        text.gameObject.SetActive(false);

    }
}
