using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    private void OnValidate()
    {
        gameObject.name = "Item - " + itemData.ItemName;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Inventory.instance.AddItem(itemData);

            Destroy(gameObject);
        }   
    }
}
