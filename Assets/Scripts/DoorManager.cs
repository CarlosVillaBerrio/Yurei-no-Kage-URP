using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
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
                door2.transform.position = new Vector3(door2.transform.position.x + .727f, door2.transform.position.y, door2.transform.position.z);
            }
        }
    }
}
