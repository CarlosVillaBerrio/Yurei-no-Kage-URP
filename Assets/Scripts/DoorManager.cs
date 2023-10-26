using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject door6;
    public GameObject door7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForDoors(ItemData _item)
    {
        if(Inventory.instance.inventoryDictionary.TryGetValue(_item, out InventoryItem value))
        {
            if(_item.name == "Blue Book")
            {
                door1.transform.rotation = Quaternion.Euler(0f, 80f, 0f);
                door2.transform.position = new Vector3(door2.transform.position.x + .727f, door2.transform.position.y, door2.transform.position.z-0.002f);
            }

            if(_item.name == "Green Book")
            {
                door3.transform.rotation = Quaternion.Euler(0f, 80f, 0f);
                door4.transform.rotation = Quaternion.Euler(0f, 190f, 0f);
            }

            if (_item.name == "Red Book")
            {
                door5.transform.rotation = Quaternion.Euler(0f, 80f, 0f);
                door6.transform.position = new Vector3(door6.transform.position.x + .727f, door6.transform.position.y, door6.transform.position.z -0.002f);
            }

            if (_item.name == "Yellow Book")
            {
                door7.transform.rotation = Quaternion.Euler(0f, -280f, 0f);
               
            }
        }
    }
}
