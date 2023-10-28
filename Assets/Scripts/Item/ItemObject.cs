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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Inventory.instance.AddItem(itemData);

            Destroy(gameObject,1f);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        Inventory.instance.AddItem(itemData);

    //        Destroy(gameObject);
    //    }   
    //}
}
